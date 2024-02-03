using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using N5_API.Project.MiddlewareSupport;

namespace N5_API.Authorize.RedisService
{
    public class RedisControlMiddleware
    {
        private readonly IDistributedCache _distributedCache;

        public RedisControlMiddleware(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<bool> HandleCacheRequest(HttpContext context)
        {
            var idempotenceKey = context.Request.Headers["x-idempotence-key"];
            if (!string.IsNullOrWhiteSpace(idempotenceKey))
            {
                Guid guidOutput;
                bool isGuidValid = Guid.TryParse(idempotenceKey, out guidOutput);
                if (!isGuidValid)
                    throw new BaseCustomException("El GUID enviado no es válido", "Error", 500);

                var element = GetElementCache(idempotenceKey);
                if (element != null)
                {
                    await HandleIdempotenceResponse(context, element);
                    return true;
                }
                else
                {
                    await SetElementCache(idempotenceKey, new RedisDTO() { date = DateTime.Now, workStates = StatusCodes.Status202Accepted });
                }
            }
            return false;
        }

        public async Task HandleCacheResponse(HttpContext context, Stream stream)
        {
            var idempotenceKey = context.Request.Headers["x-idempotence-key"];
            if (!string.IsNullOrWhiteSpace(idempotenceKey) && context.Response.StatusCode != StatusCodes.Status202Accepted)
            {
                    string body = string.Empty;
                    try
                    {
                        context.Response.Body.Seek(0, SeekOrigin.Begin);

                        using (StreamReader streamReader = new StreamReader(context.Response.Body))
                        {
                            body = await streamReader.ReadToEndAsync();
                            context.Response.Body.Seek(0, SeekOrigin.Begin);
                            await context.Response.Body.CopyToAsync(stream);
                        }

                        await SetElementCache(idempotenceKey, new RedisDTO() { date = DateTime.Now, workStates = context.Response.StatusCode, data = body });

                    }
                    catch
                    {
                        context.Response.Body = stream;
                        await SetElementCache(idempotenceKey, new RedisDTO() { date = DateTime.Now, workStates = context.Response.StatusCode, data = body });
                    }         
            }
            else
            {
                context.Response.Body.Seek(0, SeekOrigin.Begin);
                await context.Response.Body.CopyToAsync(stream);
                context.Response.Body = stream;
            }
        }



        public dynamic GetElementCache(string key)
        {
            var element = _distributedCache.Get(key);
            if (element != null)
            {
                string serializedElement = System.Text.Encoding.UTF8.GetString(element);
                return JsonConvert.DeserializeObject<RedisDTO>(serializedElement);
            }

            return element;
        }

        public async Task SetElementCache(string key, RedisDTO dto)
        {
            await _distributedCache.RemoveAsync(key);
            var optionsSerializeJson = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            string serializeObject = dto.data == null ? string.Empty : JsonConvert.SerializeObject(dto, Formatting.Indented);
            var options = new DistributedCacheEntryOptions()
                            .SetSlidingExpiration(TimeSpan.FromMinutes(5))
                            .SetAbsoluteExpiration(DateTime.Now.AddHours(6));
            await _distributedCache.SetAsync(key, System.Text.Encoding.UTF8.GetBytes(serializeObject), options);
        }



        private async Task HandleIdempotenceResponse(HttpContext context, RedisDTO memoryObject)
        {
            var optionsSerializeJson = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            var response = context.Response;
            var statusCode = context.Response.StatusCode;
            response.ContentType = "application/json; charset=utf-8 ";
            response.StatusCode = (int)memoryObject.workStates;

            var returnResponse = JsonConvert.DeserializeObject(memoryObject.data);
            await response.WriteAsync(memoryObject.data == null ? string.Empty : JsonConvert.SerializeObject(returnResponse));

        }
    }
}

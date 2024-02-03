using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using N5_API.Project.Base.Utiles;

namespace N5_API.Project.Base.Helpers.Filters
{
    public class ActionFilter:IActionFilter
    {
        private readonly ILogger<ActionFilter> logger;
        private Stopwatch stopwatch;
        private string applicationName;

        public ActionFilter(ILogger<ActionFilter> logger, string applicationName)
        {
            this.logger = logger;
            stopwatch = new Stopwatch();
            this.applicationName = applicationName;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {

            stopwatch.Start();
#if DEBUG

            string mensaje = MensajeLog.ObtenerMensajeLog((ControllerBase)context.Controller, "Inicio:" + context.HttpContext.Request.Method);
            logger.LogInformation(mensaje);
#endif
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
#if DEBUG
            string mensaje = MensajeLog.ObtenerMensajeLog((ControllerBase)context.Controller, "Fin:" + context.HttpContext.Request.Method);
            logger.LogInformation(mensaje);
#endif
            stopwatch.Stop();
            
        }

    }
}
﻿using N5_API.Project.Api.Controllers.Base;
using N5_API.Project.Base.Utiles;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using N5_API.Project.Services.Interfaces;
using System.Security;
using N5_API.Project.Base.Models;

namespace AuthManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionController : BaseContoller
    {
        private readonly IPermissionService _permissionService;
        private ILogger<PermissionController> _logger;
        public PermissionController(IPermissionService permissionService, ILogger<PermissionController> logger)
        {
            _permissionService = permissionService;
            _logger = logger;
        }

        [HttpGet("request/{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> GeById(int id)
        {
            try
            {
                var response = await _permissionService.GetPermissionAsync(id);

                if (response is null)return this.NotFound(new StatusReponse<Permission>(401, "No se ha encontrado el Permiso", response));

                return this.Ok(new StatusReponse<Permission>(200, "Persmiso Encontrado", response));
            }
            catch (Exception ex)
            {
                return this.BadRequest(new StatusReponse<Exception>(401, ex.Message, null));
            }
        }

        [HttpPut("modify/{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public async Task<IActionResult> Update(int id, [FromBody] Permission permission)
        {
            try
            {
                if (id != permission.Id || id.GetType() != typeof(int)) return this.BadRequest(new StatusReponse<Permission>(401, "A ocurrido un error intente nuevamente", permission));

                var response = await _permissionService.ModifyPermissionAsync(permission);

                if (response is null) return this.NotFound(new StatusReponse<Permission>(401, "Ha ocurrido un error inesperado, intente nuevamente", response));
                return this.Ok(new StatusReponse<Permission>(200, "Permiso Actualizado", response));
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}

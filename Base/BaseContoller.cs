using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using N5_API.Project.Base.DTOs;
using System;
using System.Text.Json;

namespace N5_API.Project.Api.Controllers.Base
{
    public abstract class BaseContoller : ControllerBase
    {
        public BaseContoller()
        {        
        }

        [NonAction]
        public BadRequestObjectResult BadRequestBase(object returns)
        {
            return base.BadRequest(new ResponseAPI(Project.Base.Enumeraciones.eCodigoStatus.SOLICITUD_INCORRECTA, returns));
        }

        [NonAction]
        public CreatedAtActionResult CreatedBase(string actionName, object routeValues, object returns)
        {
            return base.CreatedAtAction(actionName, routeValues, new ResponseAPI(Project.Base.Enumeraciones.eCodigoStatus.RECURSO_CREADO, returns));
        }

        [NonAction]
        public OkObjectResult OkBase(object returns)
        {
            return base.Ok(new ResponseAPI(Project.Base.Enumeraciones.eCodigoStatus.OK, returns));
        }

        [NonAction]
        public NotFoundObjectResult NotFoundBase(object returns)
        {
            return base.NotFound(new ResponseAPI(Project.Base.Enumeraciones.eCodigoStatus.RECURSO_NO_ENCONTRADO, returns));
        }

        [NonAction]
        public NoContentResult NoContentBase()
        {
            return base.NoContent();
        }

        /// <summary>
        /// Gets or sets AuthorizedRolesGET property
        /// </summary>
        public string[] AuthorizedRolesGET { get; set; } = new string[] { };

        /// <summary>
        /// Gets or sets AuthorizedRolesPOST property
        /// </summary>
        public string[] AuthorizedRolesPOST { get; set; } = new string[] { };

        /// <summary>
        /// Gets or sets AuthorizedRolesPUT property
        /// </summary>
        public string[] AuthorizedRolesPUT { get; set; } = new string[] { };

        /// <summary>
        /// Gets or sets AuthorizedRolesDELETE property
        /// </summary>
        public string[] AuthorizedRolesDELETE { get; set; } = new string[] { };

    }
}

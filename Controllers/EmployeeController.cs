using N5_API.Project.Api.Controllers.Base;
using N5_API.Project.Base.Utiles;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using N5_API.Project.Services.Interfaces;
using N5_API.Project.Models;

namespace AuthManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : BaseContoller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController (IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("Create")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromHeader(Name = "x-idempotence-key")][Required] string idempotencyKey, [FromBody] Employee employee)
        {
            try
            {
                var response = await _employeeService.Create(employee);
                if (response is null)
                {
                    return this.BadRequest(new { message = "Ha ocurrido un error Intente nuevamente, si el problema persiste contacte al Administrador "});
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return this.BadRequest(new StatusReponse<Exception>(401, ex.Message, null));

            }
        }


        [HttpGet("GetById/{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> GeById(int id)
        {
            try
            {
                var response = await _employeeService.GetById(id);
                if (response is null)return this.BadRequest(new StatusReponse<Employee>(201, "No se ha encontrado el Employee", response));
                return this.Ok(new StatusReponse<Employee>(200, "Employee Encontrado", response));
            }
            catch (Exception ex)
            {
                return this.BadRequest(new StatusReponse<Exception>(401, ex.Message, null));
            }
        }

        [HttpPut("Update/{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public async Task<IActionResult> Update(int id, [FromBody] Employee employee)
        {
            try
            {
                if (id != employee.Id || id.GetType() != typeof(int)) return this.BadRequest(new StatusReponse<Employee>(401, "No se ha encontrado el Employee", employee));

                var response = await _employeeService.Update(employee);

                if (response is null) return this.NotFound(new StatusReponse<Employee>(401, "Ha ocurrido un error inesperado, intente nuevamente", response));
                return this.Ok(new StatusReponse<Employee>(200, "Employee Actualizado", response));
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
        [HttpPatch("Delete/{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
             var response = await _employeeService.Delete(id);
             if (response is null) return this.BadRequest(new StatusReponse<Employee>(201, "No se ha encontrado el Employee", response));
             return this.Ok(new StatusReponse<Employee>(200, "Employee Eliminado", response));
         }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}

using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginService _service;
        public LoginController(ILoginService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.FindByLogin(loginDto);
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest();
            }
            catch (ArgumentException ae)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ae.Message);
            }
        }
    }
}

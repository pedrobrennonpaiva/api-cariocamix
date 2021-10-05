using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.Token;
using CariocaMix.Domain.Models.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using CariocaMix.Domain.Models.User;

namespace CariocaMix.API.Controllers
{
    [ApiController]
    [Route("admin")]
    public class AdminController : ControllerBase
    {
        private readonly IServiceAdmin _serviceAdmin;

        public AdminController(IServiceAdmin serviceAdmin)
        {
            _serviceAdmin = serviceAdmin;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_serviceAdmin.List());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var validateToken = AuthenticationToken.ValidateTokenAdmin(token, id);

                if(!validateToken)
                {
                    return Unauthorized();
                }

                var result = _serviceAdmin.GetById(id);

                if (!result.IsSuccess)
                {
                    return NotFound(result);
                }

                return Ok(result.ReturnObject);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateModel model)
        {
            try
            {
                var result = _serviceAdmin.Authenticate(model);

                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }

                return Ok(result.ReturnObject);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(AdminAddModel model)
        {
            try
            {
                var result = _serviceAdmin.Add(model);

                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }

                return Created("", result.ReturnObject);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult Update(AdminUpdateModel model)
        {
            try
            {
                var result = _serviceAdmin.Update(model);

                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.Token;
using CariocaMix.Domain.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CariocaMix.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IServiceUser _serviceUser;

        public UserController(IServiceUser serviceUser)
        {
            _serviceUser = serviceUser;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_serviceUser.List());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                var validateToken = ValidateTokenUser(id);

                if (!validateToken)
                {
                    return Unauthorized();
                }

                var result = _serviceUser.GetById(id);

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

        [HttpGet("name/{name}")]
        public IActionResult ListByName(string name)
        {
            try
            {
                var result = _serviceUser.ListByName(name);

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

        [HttpGet("search/{search}")]
        public IActionResult ListBySearch(string search)
        {
            try
            {
                var result = _serviceUser.ListBySearch(search);

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
                var result = _serviceUser.Authenticate(model);

                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Post(UserAddModel model)
        {
            try
            {
                var result = _serviceUser.Add(model);

                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }

                return Created(string.Empty, result.ReturnObject);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, UserUpdateModel model)
        {
            try
            {
                var validateToken = ValidateTokenUser(id);

                if (!validateToken)
                {
                    return Unauthorized();
                }

                var result = _serviceUser.Update(id, model);

                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("resetPassword/{id}&{newPassword}")]
        public IActionResult ChangePassword(long id, string newPassword)
        {
            try
            {
                var validateToken = ValidateTokenUser(id);

                if (!validateToken)
                {
                    return Unauthorized();
                }

                var result = _serviceUser.ChangePassword(new ChangePasswordModel(id, newPassword));

                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        #region Privates

        private bool ValidateTokenUser(long id)
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var validateToken = AuthenticationToken.ValidateTokenUser(token, id);

            return validateToken;
        }

        #endregion
    }
}

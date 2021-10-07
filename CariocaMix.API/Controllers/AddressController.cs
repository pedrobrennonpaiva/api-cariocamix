using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.Address;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CariocaMix.API.Controllers
{
    [ApiController]
    [Route("address")]
    public class AddressController : ControllerBase
    {
        private readonly IServiceAddress _serviceAddress;

        public AddressController(IServiceAddress serviceAddress)
        {
            _serviceAddress = serviceAddress;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var results = _serviceAddress.List();
            return Ok(results);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                var result = _serviceAddress.GetById(id);

                if (!result.IsSuccess)
                {
                    return NotFound(result);
                }

                return Ok(result.ReturnObject);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //[Authorize]
        [HttpGet("user/{userId}")]
        public IActionResult ListByUserId(long userId)
        {
            try
            {
                var result = _serviceAddress.ListByUserId(userId);

                if (!result.IsSuccess)
                {
                    return NotFound(result);
                }

                return Ok(result.ReturnObject);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Post(AddressAddModel model)
        {
            try
            {
                var result = _serviceAddress.Add(model);

                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }

                return Created("", result.ReturnObject);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, AddressUpdateModel model)
        {
            try
            {
                var result = _serviceAddress.Update(id, model);

                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }

                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

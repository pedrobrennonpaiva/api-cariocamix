using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.StoreDayHour;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CariocaMix.API.Controllers
{
    [ApiController]
    [Route("storeDayHour")]
    public class StoreDayHourController : ControllerBase
    {
        private readonly IServiceStoreDayHour _serviceStoreDayHour;

        public StoreDayHourController(IServiceStoreDayHour serviceStoreDayHour)
        {
            _serviceStoreDayHour = serviceStoreDayHour;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_serviceStoreDayHour.List());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                var result = _serviceStoreDayHour.GetById(id);

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
        public IActionResult Post(StoreDayHourAddModel model)
        {
            try
            {
                var result = _serviceStoreDayHour.Add(model);

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
        public IActionResult Update(long id, StoreDayHourUpdateModel model)
        {
            try
            {
                var result = _serviceStoreDayHour.Update(id, model);

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

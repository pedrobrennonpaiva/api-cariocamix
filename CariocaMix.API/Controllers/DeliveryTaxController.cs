using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.DeliveryTax;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CariocaMix.API.Controllers
{
    [ApiController]
    [Route("deliveryTax")]
    public class DeliveryTaxController : ControllerBase
    {
        private readonly IServiceDeliveryTax _serviceDeliveryTax;

        public DeliveryTaxController(IServiceDeliveryTax serviceDeliveryTax)
        {
            _serviceDeliveryTax = serviceDeliveryTax;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_serviceDeliveryTax.List());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                var result = _serviceDeliveryTax.GetById(id);

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
        public IActionResult Post(DeliveryTaxAddModel model)
        {
            try
            {
                var result = _serviceDeliveryTax.Add(model);

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
        public IActionResult Update(long id, DeliveryTaxUpdateModel model)
        {
            try
            {
                var result = _serviceDeliveryTax.Update(id, model);

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

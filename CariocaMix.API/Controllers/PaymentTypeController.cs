using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.PaymentType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CariocaMix.API.Controllers
{
    [ApiController]
    [Route("paymentType")]
    public class PaymentTypeController : ControllerBase
    {
        private readonly IServicePaymentType _servicePaymentType;

        public PaymentTypeController(IServicePaymentType servicePaymentType)
        {
            _servicePaymentType = servicePaymentType;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_servicePaymentType.List());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                var result = _servicePaymentType.GetById(id);

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
        public IActionResult Post(PaymentTypeAddModel model)
        {
            try
            {
                var result = _servicePaymentType.Add(model);

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
        public IActionResult Update(long id, PaymentTypeUpdateModel model)
        {
            try
            {
                var result = _servicePaymentType.Update(id, model);

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

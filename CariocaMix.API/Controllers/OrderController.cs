using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CariocaMix.API.Controllers
{
    [ApiController]
    [Route("order")]
    public class OrderController : ControllerBase
    {
        private readonly IServiceOrder _serviceOrder;

        public OrderController(IServiceOrder serviceOrder)
        {
            _serviceOrder = serviceOrder;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_serviceOrder.List());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                var result = _serviceOrder.GetById(id);

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
        public IActionResult Post(OrderAddModel model)
        {
            try
            {
                var result = _serviceOrder.Add(model);

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
        public IActionResult Update(long id, OrderUpdateModel model)
        {
            try
            {
                var result = _serviceOrder.Update(id, model);

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

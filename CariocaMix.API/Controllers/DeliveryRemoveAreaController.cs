using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.DeliveryRemoveArea;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CariocaMix.API.Controllers
{
    [ApiController]
    [Route("deliveryRemoveArea")]
    public class DeliveryRemoveAreaController : ControllerBase
    {
        private readonly IServiceDeliveryRemoveArea _serviceDeliveryRemoveArea;

        public DeliveryRemoveAreaController(IServiceDeliveryRemoveArea serviceDeliveryRemoveArea)
        {
            _serviceDeliveryRemoveArea = serviceDeliveryRemoveArea;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_serviceDeliveryRemoveArea.List());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                var result = _serviceDeliveryRemoveArea.GetById(id);

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

        [Authorize]
        [HttpGet("store/{storeId}")]
        public IActionResult ListByStoreId(long storeId)
        {
            try
            {
                var result = _serviceDeliveryRemoveArea.ListByStoreId(storeId);

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
        public IActionResult Post(DeliveryRemoveAreaAddModel model)
        {
            try
            {
                var result = _serviceDeliveryRemoveArea.Add(model);

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
        public IActionResult Update(long id, DeliveryRemoveAreaUpdateModel model)
        {
            try
            {
                var result = _serviceDeliveryRemoveArea.Update(id, model);

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

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                var result = _serviceDeliveryRemoveArea.Delete(id);

                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }

                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Authorize]
        [HttpDelete("store/{storeId}")]
        public IActionResult DeleteByStoreId(long storeId)
        {
            try
            {
                var result = _serviceDeliveryRemoveArea.DeleteByStoreId(storeId);

                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }

                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

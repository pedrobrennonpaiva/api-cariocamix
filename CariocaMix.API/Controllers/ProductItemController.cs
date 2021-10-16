using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.ProductItem;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CariocaMix.API.Controllers
{
    [ApiController]
    [Route("productItem")]
    public class ProductItemController : ControllerBase
    {
        private readonly IServiceProductItem _serviceProductItem;

        public ProductItemController(IServiceProductItem serviceProductItem)
        {
            _serviceProductItem = serviceProductItem;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var results = _serviceProductItem.List();
            return Ok(results);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                var result = _serviceProductItem.GetById(id);

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
        [HttpGet("product/{productId}")]
        public IActionResult ListByProductId(long productId)
        {
            try
            {
                var result = _serviceProductItem.ListByProductId(productId);

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
        public IActionResult Post(ProductItemAddModel model)
        {
            try
            {
                var result = _serviceProductItem.Add(model);

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
        public IActionResult Update(long id, ProductItemUpdateModel model)
        {
            try
            {
                var result = _serviceProductItem.Update(id, model);

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
                var result = _serviceProductItem.Delete(id);

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

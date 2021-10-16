using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.CategoryProduct;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CariocaMix.API.Controllers
{
    [ApiController]
    [Route("categoryProduct")]
    public class CategoryProductController : ControllerBase
    {
        private readonly IServiceCategoryProduct _serviceCategoryProduct;

        public CategoryProductController(IServiceCategoryProduct serviceCategoryProduct)
        {
            _serviceCategoryProduct = serviceCategoryProduct;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_serviceCategoryProduct.List());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                var result = _serviceCategoryProduct.GetById(id);

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
        public IActionResult Post(CategoryProductAddModel model)
        {
            try
            {
                var result = _serviceCategoryProduct.Add(model);

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
        public IActionResult Update(long id, CategoryProductUpdateModel model)
        {
            try
            {
                var result = _serviceCategoryProduct.Update(id, model);

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
                var result = _serviceCategoryProduct.Delete(id);

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

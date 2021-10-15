using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.Image;
using CariocaMix.Domain.Models.ProductItem;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CariocaMix.API.Controllers
{
    [ApiController]
    [Route("image")]
    public class ImageController : ControllerBase
    {
        private readonly IServiceImage _serviceImage;

        public ImageController(IServiceImage serviceImage)
        {
            _serviceImage = serviceImage;
        }

        [HttpGet("{filename}")]
        public IActionResult Get(string filename)
        {
            try
            {
                var result = _serviceImage.GetByName(filename);

                if (!result.IsSuccess)
                {
                    return NotFound(result);
                }

                var file = (ImageDetailsModel)result.ReturnObject;
                return File(file.Data, file.ContentType);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Post([FromForm] IFormFile file)
        {
            try
            {
                var result = _serviceImage.Add(file);

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
    }
}

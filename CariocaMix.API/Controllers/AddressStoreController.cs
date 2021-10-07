using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.AddressStore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CariocaMix.API.Controllers
{
    [ApiController]
    [Route("addressStore")]
    public class AddressStoreController : ControllerBase
    {
        private readonly IServiceAddressStore _serviceAddressStore;

        public AddressStoreController(IServiceAddressStore serviceAddressStore)
        {
            _serviceAddressStore = serviceAddressStore;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_serviceAddressStore.List());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                var result = _serviceAddressStore.GetById(id);

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
        public IActionResult Post(AddressStoreAddModel model)
        {
            try
            {
                var result = _serviceAddressStore.Add(model);

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
        public IActionResult Update(long id, AddressStoreUpdateModel model)
        {
            try
            {
                var result = _serviceAddressStore.Update(id, model);

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

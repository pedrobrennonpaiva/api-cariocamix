using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.UserCoupon;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CariocaMix.API.Controllers
{
    [ApiController]
    [Route("userCoupon")]
    public class UserCouponController : ControllerBase
    {
        private readonly IServiceUserCoupon _serviceUserCoupon;

        public UserCouponController(IServiceUserCoupon serviceUserCoupon)
        {
            _serviceUserCoupon = serviceUserCoupon;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var results = _serviceUserCoupon.List();
            return Ok(results);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                var result = _serviceUserCoupon.GetById(id);

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
        [HttpGet("user/{userId}")]
        public IActionResult ListByUserId(long userId)
        {
            try
            {
                var result = _serviceUserCoupon.ListByUserId(userId);

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
        public IActionResult Post(UserCouponAddModel model)
        {
            try
            {
                var result = _serviceUserCoupon.Add(model);

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
        public IActionResult Update(long id, UserCouponUpdateModel model)
        {
            try
            {
                var result = _serviceUserCoupon.Update(id, model);

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

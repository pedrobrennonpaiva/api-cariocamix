using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.UserCoupon;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CariocaMix.API.Controllers
{
    [ApiController]
    [Route("user/coupon")]
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
            return Ok(_serviceUserCoupon.List());
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

using Discount.API.Entities;
using Discount.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Discount.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountRepository discountRepository;

        public DiscountController(IDiscountRepository discountRepository)
        {
            this.discountRepository = discountRepository ?? throw new ArgumentNullException(nameof(discountRepository));
        }

        [HttpGet("{productName}", Name = "GetDiscount")]
        public async Task<ActionResult<CouponEntity>> GetDiscount(string productName)
        {
            var coupon = await discountRepository.GetDiscount(productName);
            return Ok(coupon);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CouponEntity), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CouponEntity>> CreateCoupon([FromBody] CouponEntity coupon)
        {
            await discountRepository.CreateDiscount(coupon);
            return CreatedAtRoute("GetDiscount", new { productName = coupon.ProductName }, coupon);
        }

        [HttpPut]
        [ProducesResponseType(typeof(CouponEntity), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CouponEntity>> UpdateDiscount([FromBody] CouponEntity coupon)
        {
            return Ok(await discountRepository.UpdateDiscount(coupon));
        }

        [HttpDelete]
        public async Task DeleteDiscount(string productName)
        {
            await discountRepository.DeleteDiscount(productName);
        }
    }
}

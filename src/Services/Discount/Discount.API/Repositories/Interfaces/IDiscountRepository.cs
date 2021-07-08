using Discount.API.Entities;
using System.Threading.Tasks;

namespace Discount.API.Repositories.Interfaces
{
    public interface IDiscountRepository
    {
        Task<CouponEntity> GetDiscount(string productName);
        Task<bool> CreateDiscount(CouponEntity coupon);
        Task<bool> UpdateDiscount(CouponEntity coupon);
        Task<bool> DeleteDiscount(string productName);
    }
}

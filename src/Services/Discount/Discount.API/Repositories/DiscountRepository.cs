using Dapper;
using Discount.API.Entities;
using Discount.API.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace Discount.API.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration configuration;

        public DiscountRepository(IConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<bool> CreateDiscount(CouponEntity coupon)
        {
            using var connection = new NpgsqlConnection(
                configuration.GetValue<string>("DatabaseSettingsConnectionString"));

            var affected = await connection.ExecuteAsync(
                "INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Desrciption, @Amount)",
                new
                {
                    ProductName = coupon.ProductName,
                    Description = coupon.Description,
                    Amount = coupon.Amount,
                });

            if (affected == 0)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            using var connection = new NpgsqlConnection(
                configuration.GetValue<string>("DatabaseSettingsConnectionString"));

            var affected = await connection.ExecuteAsync(
                "DELETE FROM Coupon WHERE ProductName = @ProductName",
                new
                {
                    ProductName = productName,
                });

            if (affected == 0)
            {
                return false;
            }

            return true;
        }

        public async Task<CouponEntity> GetDiscount(string productName)
        {
            using var connection = new NpgsqlConnection(
                configuration.GetValue<string>("DatabaseSettingsConnectionString"));

            var coupon = await connection.QueryFirstOrDefaultAsync<CouponEntity>(
                "SELECT * FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName });

            if (coupon is null)
            {
                return new CouponEntity
                {
                    ProductName = "No Discount",
                    Amount = 0,
                    Description = "No Discount Desc",
                };
            }

            return coupon;
        }

        public async Task<bool> UpdateDiscount(CouponEntity coupon)
        {
            using var connection = new NpgsqlConnection(
                configuration.GetValue<string>("DatabaseSettingsConnectionString"));

            var affected = await connection.ExecuteAsync(
                "UPDATE Coupon SET ProductName = @ProductName, Description = @Description, Amount = @Amount WHERE Id = @Id",
                new
                {
                    ProductName = coupon.ProductName,
                    Description = coupon.Description,
                    Amount = coupon.Amount,
                    Id = coupon.Id,
                });

            if (affected == 0)
            {
                return false;
            }

            return true;
        }
    }
}

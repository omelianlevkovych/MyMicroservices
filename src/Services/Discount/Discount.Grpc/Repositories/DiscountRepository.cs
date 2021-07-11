using Dapper;
using Discount.Grpc.Configuration.Interfaces;
using Discount.Grpc.Entities;
using Discount.Grpc.Repositories.Interfaces;
using Npgsql;
using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace Discount.API.Repositories
{
    public class DiscountRepository : IDiscountRepository, IDisposable
    {
        private readonly IConfigurationManager configurationManager;
        private readonly DbConnection dbConnection;

        public DiscountRepository(
            IConfigurationManager configurationManager)
        {
            this.configurationManager = configurationManager ?? throw new ArgumentNullException(nameof(configurationManager));

            dbConnection = new NpgsqlConnection(
                this.configurationManager.GetConfiguration<string>("DatabaseSettings:ConnectionString"));
        }

        public async Task<bool> CreateDiscount(CouponEntity coupon)
        {
            var affected = await dbConnection.ExecuteAsync(
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
            var affected = await dbConnection.ExecuteAsync(
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
            var coupon = await dbConnection.QueryFirstOrDefaultAsync<CouponEntity>(
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
            var affected = await dbConnection.ExecuteAsync(
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

        public void Dispose()
        {
            this.dbConnection.Dispose();
        }
    }
}

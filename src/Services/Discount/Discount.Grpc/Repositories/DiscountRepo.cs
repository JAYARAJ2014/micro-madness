using System;
using System.Threading.Tasks;
using Dapper;
using Discount.Grpc.Entities;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Discount.Grpc.Repositories
{
    public class DiscountRepo : IDiscountRepo
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DiscountRepo(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _connectionString = _configuration.GetValue<string>("DatabaseSettings:ConnectionString");
        }
        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            using var connection = new NpgsqlConnection(_connectionString);

            var affected = await connection.ExecuteAsync
            ("INSERT INTO Coupon(ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)",
            new { coupon.ProductName, coupon.Description, coupon.Amount });

            return affected != 0;
        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            using var connection = new NpgsqlConnection(_connectionString);

            var affected = await connection.ExecuteAsync
            ("DELETE FROM Coupon WHERE ProductName=@ProductName", new { ProductName = productName });

            return !(affected == 0);
        }

        public async Task<Coupon> GetDiscount(string productName)
        {
            using var connection = new NpgsqlConnection(_connectionString);

            var coupon = await connection.QueryFirstAsync<Coupon>
            ("SELECT * FROM Coupon WHERE ProductName=@ProductName", new { ProductName = productName });

            return coupon ?? new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount" };
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            System.Console.WriteLine(coupon.ToString());
            var affected = await connection.ExecuteAsync
            ("UPDATE Coupon SET ProductName=@ProductName, Description=@Description, Amount=@Amount WHERE ID=@Id", new { coupon.ProductName, coupon.Description, coupon.Amount, coupon.Id });

            return !(affected == 0);
        }
    }
}
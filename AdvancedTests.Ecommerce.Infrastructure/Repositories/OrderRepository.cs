using System.Data;
using AdvancedTests.Ecommerce.Domain.Entities;
using AdvancedTests.Ecommerce.Domain.Repositories;
using Dapper;

namespace AdvancedTests.Ecommerce.Infrastructure.Repositories;

public class OrderRepository (IDbConnection connection) : IOrderRepository
{
    public async Task<int> AddAsync(Order order)
    {
        var sql = @"
                insert into orders (customer_id, state, city, street, zip_code, number, amount, status)
                values (@customerId, @status, @city, @street, @zip_code, @number, @amount);
                select LAST_INSERT_ID();";
        var parameters = new
        {
            CustomerId = order.Customer.Id,
            order.Address.State,
            order.Address.City,
            order.Address.Street,
            order.Address.ZipCode,
            order.Address.Number,
            order.Amount,
            order.Status
        };
        
        return await connection.ExecuteScalarAsync<int>(sql, parameters);
    }
}
using System.Data;
using AdvancedTests.Ecommerce.Domain.Entities;
using AdvancedTests.Ecommerce.Domain.Repositories;
using Dapper;

namespace AdvancedTests.Ecommerce.Infrastructure.Repositories;

public class CustomerRepository (IDbConnection connection) : ICustomerRepository
{
    public async Task<Customer?> GetByIdAsync(int Id)
    {
        var custumer = await connection.QueryAsync(
            @"select id, name, is_premium from customers where id = @id", new { Id = Id });
        var customerData = custumer.FirstOrDefault();
        return customerData == null
            ? null
            : new Customer(customerData.Id, customerData.Name, customerData.IsPremium);
    }
}
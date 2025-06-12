using System.Threading.Tasks;
using TestAdvanced.ECommerce.Application.Entities;

namespace TestAdvanced.ECommerce.Domain.Repositories;

public interface ICustomerRepository
{
    Task<Customer?> GetByIdAsync(int Id);
}
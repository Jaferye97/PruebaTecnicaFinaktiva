using Domain.Models.Customers;

namespace Application.Ports
{
    public interface ICustomersRepositorySqlServerPort
    {
        Task<CustomersModel> GetAsync(Guid id);
        Task<IEnumerable<CustomersModel>> GetAsync();
        Task<CustomersModel> AddAsync(CustomersModel model);
        Task<CustomersModel> UpdateAsync(CustomersModel model);
    }
}

using Domain.Models.Customers;

namespace Application.UseCases.Customers.Interfaces
{
    public interface IGetCustomersUseCase
    {
        Task<IEnumerable<CustomersModel>> ExecuteAsync();
    }
}

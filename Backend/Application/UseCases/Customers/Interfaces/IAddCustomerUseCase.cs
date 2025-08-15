using Domain.Models.Customers;

namespace Application.UseCases.Customers.Interfaces
{
    public interface IAddCustomerUseCase
    {
        Task<CustomersModel> ExecuteAsync(CustomersModel model);
    }
}

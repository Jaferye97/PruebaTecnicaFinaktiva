using Domain.Models.Customers;

namespace Application.UseCases.Customers.Interfaces
{
    public interface IUpdateCustomerUseCase
    {
        Task<CustomersModel> ExecuteAsync(CustomersModel model);
    }
}

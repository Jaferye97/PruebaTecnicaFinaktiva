using Domain.Models.Customers;

namespace Application.UseCases.Customers.Interfaces
{
    public interface IGetCustomerByIdUseCase
    {
        Task<CustomersModel> ExecuteAsync(Guid id);
    }
}

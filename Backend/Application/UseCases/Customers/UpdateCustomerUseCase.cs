using Application.Ports;
using Application.UseCases.Customers.Interfaces;
using Domain.Models.Customers;

namespace Application.UseCases.Customers
{
    public class UpdateCustomerUseCase : IUpdateCustomerUseCase
    {
        private readonly ICustomersRepositorySqlServerPort _repository;

        public UpdateCustomerUseCase(ICustomersRepositorySqlServerPort repository)
        {
            _repository = repository;
        }

        public async Task<CustomersModel> ExecuteAsync(CustomersModel model)
        {
            return await _repository.UpdateAsync(model);
        }
    }
}

using Application.Ports;
using Application.UseCases.Customers.Interfaces;
using Domain.Models.Customers;

namespace Application.UseCases.Customers
{
    public class AddCustomerUseCase : IAddCustomerUseCase
    {
        private readonly ICustomersRepositorySqlServerPort _repository;

        public AddCustomerUseCase(ICustomersRepositorySqlServerPort repository)
        {
            _repository = repository;
        }

        public async Task<CustomersModel> ExecuteAsync(CustomersModel model)
        {
            return await _repository.AddAsync(model);
        }
    }
}

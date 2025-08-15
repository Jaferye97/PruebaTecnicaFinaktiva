using Application.Ports;
using Application.UseCases.Customers.Interfaces;
using Domain.Models.Customers;

namespace Application.UseCases.Customers
{
    public class GetCustomerByIdUseCase : IGetCustomerByIdUseCase
    {
        private readonly ICustomersRepositorySqlServerPort _repository;

        public GetCustomerByIdUseCase(ICustomersRepositorySqlServerPort repository)
        {
            _repository = repository;
        }

        public async Task<CustomersModel> ExecuteAsync(int id)
        {
            return await _repository.GetAsync(id);
        }
    }
}

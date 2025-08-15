using Application.Ports;
using Application.UseCases.Customers.Interfaces;
using Domain.Models.Customers;

namespace Application.UseCases.Customers
{
    public class GetCustomersUseCase : IGetCustomersUseCase
    {
        private readonly ICustomersRepositorySqlServerPort _repository;

        public GetCustomersUseCase(ICustomersRepositorySqlServerPort repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CustomersModel>> ExecuteAsync()
        {
            return await _repository.GetAsync();
        }
    }
}

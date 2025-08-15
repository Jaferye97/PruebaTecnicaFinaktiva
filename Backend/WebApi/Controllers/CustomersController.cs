using Application.UseCases.Customers;
using Application.UseCases.Customers.Interfaces;
using Domain.Models.Customers;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IGetCustomersUseCase _getCustomersUseCase;
        private readonly IGetCustomerByIdUseCase _getCustomersByIdUseCase;
        private readonly IAddCustomerUseCase _addCustomerUseCase;
        private readonly IUpdateCustomerUseCase _updateCustomerUseCase;

        public CustomersController(IGetCustomerByIdUseCase getCustomerByIdUseCase, IGetCustomersUseCase getCustomersUseCase, IAddCustomerUseCase addCustomerUseCase, IUpdateCustomerUseCase updateCustomerUseCase)
        {
            _getCustomersUseCase = getCustomersUseCase;
            _getCustomersByIdUseCase = getCustomerByIdUseCase;
            _addCustomerUseCase = addCustomerUseCase;
            _updateCustomerUseCase = updateCustomerUseCase;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _getCustomersUseCase.ExecuteAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var result = await _getCustomersByIdUseCase.ExecuteAsync(id);
            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> AddAsync([FromBody] CustomersModel model)
        {
            var result = await _addCustomerUseCase.ExecuteAsync(model);
            return Ok(result);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateAsync([FromBody] CustomersModel model)
        {
            var result = await _updateCustomerUseCase.ExecuteAsync(model);
            return Ok(result);
        }
    }
}

using Application.UseCases.EventLogs.Interfaces;
using Domain.Models.EventLogs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventLogsController : ControllerBase
    {
        private readonly IGetEventLogsUseCase _getEventLogsUseCase;
        private readonly IGetEventLogByIdUseCase _getEventLogByIdUseCase;
        private readonly IAddEventLogUseCase _addEventLogUseCase;
        private readonly IUpdateEventLogUseCase _updateEventLogUseCase;

        public EventLogsController(
            IGetEventLogByIdUseCase getEventLogByIdUseCase, 
            IGetEventLogsUseCase getEventLogsUseCase, 
            IAddEventLogUseCase addEventLogUseCase, 
            IUpdateEventLogUseCase updateEventLogUseCase)
        {
            _getEventLogsUseCase = getEventLogsUseCase;
            _getEventLogByIdUseCase = getEventLogByIdUseCase;
            _addEventLogUseCase = addEventLogUseCase;
            _updateEventLogUseCase = updateEventLogUseCase;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _getEventLogsUseCase.ExecuteAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var result = await _getEventLogByIdUseCase.ExecuteAsync(id);
            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> AddAsync([FromBody] EventLogsModel model)
        {
            var result = await _addEventLogUseCase.ExecuteAsync(model);
            return Ok(result);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateAsync([FromBody] EventLogsModel model)
        {
            var result = await _updateEventLogUseCase.ExecuteAsync(model);
            return Ok(result);
        }
    }
}

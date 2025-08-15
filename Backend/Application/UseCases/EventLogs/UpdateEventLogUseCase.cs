using Application.Ports;
using Application.UseCases.EventLogs.Interfaces;
using Domain.Models.EventLogs;

namespace Application.UseCases.EventLogs
{
    public class UpdateEventLogUseCase : IUpdateEventLogUseCase
    {
        private readonly IEventLogsRepositorySqlServerPort _repository;

        public UpdateEventLogUseCase(IEventLogsRepositorySqlServerPort repository)
        {
            _repository = repository;
        }

        public async Task<EventLogsModel> ExecuteAsync(EventLogsModel model)
        {
            return await _repository.UpdateAsync(model);
        }
    }
}

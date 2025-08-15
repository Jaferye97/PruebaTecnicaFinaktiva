using Application.Ports;
using Application.UseCases.EventLogs.Interfaces;
using Domain.Models.EventLogs;

namespace Application.UseCases.EventLogs
{
    public class GetEventLogByIdUseCase : IGetEventLogByIdUseCase
    {
        private readonly IEventLogsRepositorySqlServerPort _repository;

        public GetEventLogByIdUseCase(IEventLogsRepositorySqlServerPort repository)
        {
            _repository = repository;
        }

        public async Task<EventLogsModel> ExecuteAsync(int id)
        {
            return await _repository.GetAsync(id);
        }
    }
}

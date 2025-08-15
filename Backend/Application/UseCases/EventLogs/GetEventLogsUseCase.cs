using Application.Ports;
using Application.UseCases.EventLogs.Interfaces;
using Domain.Models.EventLogs;

namespace Application.UseCases.EventLogs
{
    public class GetEventLogsUseCase : IGetEventLogsUseCase
    {
        private readonly IEventLogsRepositorySqlServerPort _repository;

        public GetEventLogsUseCase(IEventLogsRepositorySqlServerPort repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EventLogsModel>> ExecuteAsync()
        {
            return await _repository.GetAsync();
        }
    }
}

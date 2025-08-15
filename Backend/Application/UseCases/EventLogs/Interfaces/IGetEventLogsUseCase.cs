using Domain.Models.EventLogs;

namespace Application.UseCases.EventLogs.Interfaces
{
    public interface IGetEventLogsUseCase
    {
        Task<IEnumerable<EventLogsModel>> ExecuteAsync();
    }
}

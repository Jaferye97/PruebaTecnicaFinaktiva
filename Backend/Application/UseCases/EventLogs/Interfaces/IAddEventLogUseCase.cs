using Domain.Models.EventLogs;

namespace Application.UseCases.EventLogs.Interfaces
{
    public interface IAddEventLogUseCase
    {
        Task<EventLogsModel> ExecuteAsync(EventLogsModel model);
    }
}

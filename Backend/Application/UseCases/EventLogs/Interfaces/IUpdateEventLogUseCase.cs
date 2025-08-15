using Domain.Models.EventLogs;

namespace Application.UseCases.EventLogs.Interfaces
{
    public interface IUpdateEventLogUseCase
    {
        Task<EventLogsModel> ExecuteAsync(EventLogsModel model);
    }
}

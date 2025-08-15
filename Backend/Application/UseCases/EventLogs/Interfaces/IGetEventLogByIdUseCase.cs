using Domain.Models.EventLogs;

namespace Application.UseCases.EventLogs.Interfaces
{
    public interface IGetEventLogByIdUseCase
    {
        Task<EventLogsModel> ExecuteAsync(int id);
    }
}

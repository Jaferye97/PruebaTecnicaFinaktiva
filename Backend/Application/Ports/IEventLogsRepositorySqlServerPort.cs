using Domain.Models.EventLogs;

namespace Application.Ports
{
    public interface IEventLogsRepositorySqlServerPort
    {
        Task<EventLogsModel> GetAsync(int id);
        Task<IEnumerable<EventLogsModel>> GetAsync();
        Task<EventLogsModel> AddAsync(EventLogsModel model);
        Task<EventLogsModel> UpdateAsync(EventLogsModel model);
    }
}

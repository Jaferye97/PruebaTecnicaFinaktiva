using Application.Ports;
using Domain.Models.EventLogs;
using ReporitorySqlServer.Context;
using ReporitorySqlServer.Entities;
using ReporitorySqlServer.Mappers;

namespace ReporitorySqlServer.Repositories
{
    public class EventLogsRepository : BaseRepository<EventLogsEntity, EventLogsModel, int>, IEventLogsRepositorySqlServerPort
    {
        public EventLogsRepository(EntityDbContext context) : base(context, entity => entity.ToDomain(), entity => entity.ToEntity())
        {
        }

        public async Task<EventLogsModel> GetAsync(int id) => await base.GetAsync(id);

        public async Task<IEnumerable<EventLogsModel>> GetAsync() => await base.GetAsync();

        public async Task<EventLogsModel> AddAsync(EventLogsModel model) => EventLogsMapper.ToDomain(await base.AddAsync(model));

        public async Task<EventLogsModel> UpdateAsync(EventLogsModel model) => EventLogsMapper.ToDomain(await base.UpdateAsync(model));
    }
}

using Domain.Models.EventLogs;
using ReporitorySqlServer.Entities;

namespace ReporitorySqlServer.Mappers
{
    public static class EventLogsMapper
    {
        public static EventLogsModel ToDomain(this EventLogsEntity entity) => new EventLogsModel
        {
            Id = entity.Id,
            Description = entity.Description,
            EventDate = entity.EventDate,
            EventType = entity.EventType,
            ExceptionMessage = entity.ExceptionMessage,
            ReferenceEntity = entity.ReferenceEntity,
            ReferenceId = entity.ReferenceId,
            CreatedAt = entity.CreatedAt,
        };

        public static EventLogsEntity ToEntity(this EventLogsModel domain) => new EventLogsEntity
        {
            Id = domain.Id,
            Description = domain.Description,
            EventDate = domain.EventDate,
            EventType = domain.EventType,
            ExceptionMessage = domain.ExceptionMessage,
            ReferenceEntity = domain.ReferenceEntity,
            ReferenceId = domain.ReferenceId,
            CreatedAt = domain.CreatedAt,
        };
    }
}

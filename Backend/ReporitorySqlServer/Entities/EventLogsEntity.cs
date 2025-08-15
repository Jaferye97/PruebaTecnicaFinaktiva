using System.ComponentModel.DataAnnotations.Schema;
using ReporitorySqlServer.Entities.Constants;

namespace ReporitorySqlServer.Entities
{
    [Table("EventLogs")]
    public class EventLogsEntity : IEntity<int>
    {
        public int Id { get; set; }
        public DateTime EventDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public string EventType { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int? ReferenceId { get; set; }
        public string? ReferenceEntity { get; set; }
        public string? ExceptionMessage { get; set; }
    }
}

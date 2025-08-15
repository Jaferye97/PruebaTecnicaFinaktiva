namespace Domain.Models.EventLogs
{
    public class EventLogsModel
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

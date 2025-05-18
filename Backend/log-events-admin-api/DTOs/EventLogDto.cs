namespace log_events_admin_api.DTOs
{
    public class EventLogDto
    {
        public int Id { get; set; }
        public DateTime EventDate { get; set; }
        public string Description { get; set; }
        public int EventTypeId { get; set; }
        public string EventTypeName { get; set; }
    }

}

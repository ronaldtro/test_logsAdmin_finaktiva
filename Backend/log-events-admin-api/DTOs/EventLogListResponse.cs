namespace log_events_admin_api.DTOs
{
    public class EventLogListResponse
    {
        public bool Success { get; set; }
        public IEnumerable<EventLogDto> Data { get; set; }
    }
}

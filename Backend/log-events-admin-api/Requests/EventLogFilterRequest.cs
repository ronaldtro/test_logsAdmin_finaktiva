namespace log_events_admin_api.Requests
{
    public class EventLogFilterRequest
    {
        public int? EventTypeId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}

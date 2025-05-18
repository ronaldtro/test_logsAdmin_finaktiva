using System.ComponentModel.DataAnnotations;

namespace log_events_admin_api.Requests
{
    public class EventLogRequest
    {
        [Required]
        public string event_date { get; set; }
        [Required]
        public string event_description { get; set; }

    }
}

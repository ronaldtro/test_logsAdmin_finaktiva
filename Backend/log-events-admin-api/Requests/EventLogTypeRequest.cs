using System.ComponentModel.DataAnnotations;

namespace log_events_admin_api.Requests
{
    public class EventLogTypeRequest
    {
        [Required]
        public string event_type_name { get; set; }

        [Required]
        public string event_type_description { get; set; }
    }
}

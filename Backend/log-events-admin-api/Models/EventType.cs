using System;
using System.Collections.Generic;

namespace log_events_admin_api.Models;

public partial class EventType
{
    public int Id { get; set; }

    public string? EventTypeName { get; set; }

    public string? EventTypeDescription { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<EventLog> EventLogs { get; set; } = new List<EventLog>();
}

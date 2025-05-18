using System;
using System.Collections.Generic;

namespace log_events_admin_api.Models;

public partial class EventLog
{
    public int Id { get; set; }

    public DateTime? EventDate { get; set; }

    public string? EventDescription { get; set; }

    public int? EventTypeId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual EventType? EventType { get; set; }
}

using log_events_admin_api.DTOs;
using log_events_admin_api.Requests;
using log_events_admin_api.Enums;

namespace log_events_admin_api.Services
{
    public interface IEventLogService
    {
        Task<EventLogListResponse> GetEventLogsAsync(EventLogFilterRequest filter);
        Task<EventLogDto> CreateEventLogAsync(EventLogRequest request, EventSource source);
        Task<EventTypeDto> CreateEventLogTypeAsync(EventLogTypeRequest request);
        Task<IEnumerable<EventTypeDto>> GetEventLogTypesAsync();
    }
}

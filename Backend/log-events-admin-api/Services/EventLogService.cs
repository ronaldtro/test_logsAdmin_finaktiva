using log_events_admin_api.DTOs;
using log_events_admin_api.Models;
using log_events_admin_api.Requests;
using Microsoft.EntityFrameworkCore;
using log_events_admin_api.Enums;

namespace log_events_admin_api.Services
{
    public class EventLogService : IEventLogService
    {
        private readonly RegistrationContext _db;
        private readonly ILogger<EventLogService> _logger;

        public EventLogService(RegistrationContext db, ILogger<EventLogService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<EventLogListResponse> GetEventLogsAsync(EventLogFilterRequest filter)
        {
            try
            {
                
                IQueryable<EventLog> query = _db.EventLogs.Include(e => e.EventType);
              
                if (filter.EventTypeId.HasValue)
                    query = query.Where(e => e.EventTypeId == filter.EventTypeId.Value);
    
                if (filter.DateFrom.HasValue)
                    query = query.Where(e => e.EventDate >= filter.DateFrom.Value);

                if (filter.DateTo.HasValue)
                    query = query.Where(e => e.EventDate <= filter.DateTo.Value);

                
                var list = await query
                    .OrderByDescending(e => e.EventDate)
                    .ToListAsync();

                var dtos = list.Select(e => new EventLogDto
                {
                    Id = e.Id,
                    EventDate = e.EventDate!.Value,
                    Description = e.EventDescription!,
                    EventTypeId = e.EventTypeId!.Value,
                    EventTypeName = e.EventType!.EventTypeName!
                });

                return new EventLogListResponse
                {
                    Success = true,
                    Data = dtos
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetEventLogsAsync fallo con filtro {@Filter}", filter);
                return new EventLogListResponse
                {
                    Success = false,
                    Data = Array.Empty<EventLogDto>()
                };
            }
        }

        public async Task<EventLogDto> CreateEventLogAsync(EventLogRequest request, EventSource source)
        {

            var entity = new EventLog
            {
                EventDate = DateTime.Parse(request.event_date),
                EventDescription = request.event_description,
                EventTypeId = (int)source,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            using var tx = await _db.Database.BeginTransactionAsync();

            try
            {
                _db.EventLogs.Add(entity);
                await _db.SaveChangesAsync();
                await tx.CommitAsync();

                await _db.Entry(entity).Reference(e => e.EventType).LoadAsync();

                return new EventLogDto
                {
                    Id = entity.Id,
                    EventDate = entity.EventDate!.Value,
                    Description = entity.EventDescription!,
                    EventTypeId = entity.EventTypeId!.Value,
                    EventTypeName = entity.EventType!.EventTypeName!
                };
            }
            catch (Exception ex)
            {
                await tx.RollbackAsync();
                _logger.LogError(ex, "CreateEventLogAsync fallo {@Request}, Source={Source}", request, source);
                throw;
            }
        }

        public async Task<EventTypeDto> CreateEventLogTypeAsync(EventLogTypeRequest request)
        {
            using var tx = await _db.Database.BeginTransactionAsync();
            try
            {
  
                var exists = await _db.EventTypes
                    .AnyAsync(t => t.EventTypeName == request.event_type_name);
                if (exists)
                    throw new InvalidOperationException("El tipo de evento ya existe.");

                var entity = new EventType
                {
                    EventTypeName = request.event_type_name,
                    EventTypeDescription = request.event_type_description,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                _db.EventTypes.Add(entity);
                await _db.SaveChangesAsync();
                await tx.CommitAsync();

                return new EventTypeDto
                {
                    Id = entity.Id,
                    Name = entity.EventTypeName!,
                    Description = entity.EventTypeDescription!
                };
            }
            catch (Exception ex)
            {
                await tx.RollbackAsync();
                _logger.LogError(ex, "CreateEventLogTypeAsync fallo {@Request}", request);
                throw;
            }
        }

        public async Task<IEnumerable<EventTypeDto>> GetEventLogTypesAsync()
        {
            try
            {
                var list = await _db.EventTypes.ToListAsync();
                return list.Select(t => new EventTypeDto
                {
                    Id = t.Id,
                    Name = t.EventTypeName!,
                    Description = t.EventTypeDescription!
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetEventLogTypesAsync fallo");
                return Array.Empty<EventTypeDto>();
            }
        }
    }

}

using log_events_admin_api.DTOs;
using log_events_admin_api.Requests;
using log_events_admin_api.Services;
using log_events_admin_api.Enums;         
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace log_events_admin_api.Controllers
{
    [Route("api/event-logs")]
    [ApiController]
    public class EventLogController : ControllerBase
    {
        private readonly IEventLogService _eventLogService;
        private readonly ILogger<EventLogController> _logger;

        public EventLogController(IEventLogService eventLogService,
                                  ILogger<EventLogController> logger)
        {
            _eventLogService = eventLogService;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<EventLogListResponse>> GetEventLogs([FromQuery] EventLogFilterRequest filter)
        {
            try
            {
                var result = await _eventLogService.GetEventLogsAsync(filter);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener event logs con filtros {@Filter}", filter);
                return StatusCode(500, new { success = false, message = "Error interno del servidor." });
            }
        }

   
        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<EventLogDto>> CreateEventLog([FromBody] EventLogRequest request)
        {
            try
            {
                var dto = await _eventLogService.CreateEventLogAsync(request, EventSource.Api);
                return CreatedAtAction(nameof(GetEventLogs), new { id = dto.Id }, dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear event log {@Request}", request);
                return StatusCode(500, new { success = false, message = "Error interno del servidor." });
            }
        }

  
        [HttpPost("manual")]
        [AllowAnonymous]
        public async Task<ActionResult<EventLogDto>> CreateEventLogManual([FromBody] EventLogRequest request)
        {
            try
            {
                var dto = await _eventLogService.CreateEventLogAsync(request, EventSource.Manual);
                return CreatedAtAction(nameof(GetEventLogs), new { id = dto.Id }, dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear event log manual {@Request}", request);
                return StatusCode(500, new { success = false, message = "Error interno del servidor." });
            }
        }

        [HttpGet("types")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<EventTypeDto>>> GetEventLogTypes()
        {
            try
            {
                var types = await _eventLogService.GetEventLogTypesAsync();
                return Ok(types);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener tipos de evento");
                return StatusCode(500, new { success = false, message = "Error interno del servidor." });
            }
        }

        [HttpPost("types")]
        [AllowAnonymous]
        public async Task<ActionResult<EventTypeDto>> CreateEventLogType([FromBody] EventLogTypeRequest request)
        {
            try
            {
                var dto = await _eventLogService.CreateEventLogTypeAsync(request);
                return CreatedAtAction(nameof(GetEventLogTypes), new { id = dto.Id }, dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear tipo de evento {@Request}", request);
                return StatusCode(500, new { success = false, message = "Error interno del servidor." });
            }
        }

    }
}

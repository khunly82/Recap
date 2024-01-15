using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recap.API.DTO;
using Recap.BLL.Services;

namespace Recap.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarEventController(CalendarEventService calendarEventService) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(calendarEventService.GetEvents().Select(e => new CalendarEventDTO(e)));
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddCalendarEventDTO dto)
        {
            calendarEventService.AddEvent(dto.Title, dto.Start, dto.End);
            return Created("", null);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]int id, [FromBody] AddCalendarEventDTO dto)
        {
            calendarEventService.UpdateEvent(id, dto.Title, dto.Start, dto.End);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            calendarEventService.DeleteEvent(id);
            return NoContent();
        }
    }
}

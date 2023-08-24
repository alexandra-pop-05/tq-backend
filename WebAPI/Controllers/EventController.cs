using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TQ_Project.Application.Interfaces;
using TQ_Project.Application.Models.Event;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EventCreate>>> GetAllEvents()
        {
            var result = await _eventService.GetAllEvents();
            if (result is null)
            {
                return BadRequest("No events found");
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventCreate>> GetEventById(int id)
        {
            var result = await _eventService.GetEventById(id);

            if (result is null)
            {
                return BadRequest("Event not found!");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<EventCreate>>> AddEvent([FromBody] EventCreate eventt) //optional attribute expecting user object in the body
        {
            var result = await _eventService.AddEvent(eventt);

            if (result is null)
            {
                return BadRequest("Event with the provided id already exists!");
            }
            return Ok(result);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EventCreate>> UpdateEventById(int id, EventCreate requestedEvent)
        {
            var result = await _eventService.UpdateEventById(id, requestedEvent);
            if (result is null) return NotFound("Event not found!");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<EventCreate>>> DeleteEvent(int id)
        {
            var result = await _eventService.GetEventById(id);
            if (result is null) return NotFound("Event not found!");

            await _eventService.DeleteEvent(id);

            return Ok("Event deleted!");
        }
    }
}

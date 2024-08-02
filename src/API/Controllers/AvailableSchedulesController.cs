using Application.AvailableSchedule.Commands;
using Application.AvailableSchedule.Queries;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AvailableSchedulesController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAvailableSchedules()
    {
        var query = new ListAvailableSchedulesQuery();
        var schedules = await Mediator.Send(query);
        return Ok(schedules);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAvailableSchedule([FromBody] AddAvailableScheduleCommand command)
    {
        var schedule = await Mediator.Send(command);
        return Ok(schedule);
    }


    [HttpPut]
    public async Task<IActionResult> EditAvailableSchedule([FromBody] EditAvailableScheduleCommand command)
    {
        var schedule = await Mediator.Send(command);
        return Ok(schedule);
    }
}

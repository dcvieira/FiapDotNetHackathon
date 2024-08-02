using Application.Appointment.Commands;
using Application.Appointment.Queries;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;



[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAppointments()
    {
        var query = new ListMyAppointmentsQuery();
        var appointments = await Mediator.Send(query);
        return Ok(appointments);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAppointment([FromBody] BookAppointmentCommand command)
    {
        var appointment = await Mediator.Send(command);
        return Ok(appointment);
    }
}

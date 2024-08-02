
using Application.Doctor.Command;
using Application.Doctor.Queries;
using Application.Patient.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;



[ApiController]
[Route("api/[controller]")]
public class PatientsController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllPatients()
    {
        var query = new ListPatientsQuery();
        var patients = await Mediator.Send(query);
        return Ok(patients);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> RegisterPatient([FromBody] RegisterPatientCommand command)
    {
        var patient = await Mediator.Send(command);
        return Ok(patient);
    }
}


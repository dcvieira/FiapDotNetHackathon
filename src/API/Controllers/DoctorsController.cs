using Application.Doctor.Command;
using Application.Doctor.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class DoctorsController : ApiControllerBase
{
    private readonly IConfiguration _configuration;

    public DoctorsController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    [HttpGet("teste")]
    public async Task<IActionResult> teste()
    {
        var myValue = _configuration["ConnectionStrings:DefaultConnection"];
        return Ok(myValue);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDoctors()
    {
        var query = new ListDoctorsQuery();
        var doctors = await Mediator.Send(query);
        return Ok(doctors);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> RegisterDoctor([FromBody] RegisterDoctorCommand command)
    {
        var doctor = await Mediator.Send(command);
        return Ok(doctor);
    }
}


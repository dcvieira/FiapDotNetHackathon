using Application.Appointment.Dtos;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Doctor.Dtos;
using Application.Patient.Dtos;
using Application.User;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Appointment.Queries;


public class ListMyAppointmentsQuery : IRequest<List<AppointmentDto>>
{
}

public class ListMyAppointmentsHandler : IRequestHandler<ListMyAppointmentsQuery, List<AppointmentDto>>
{

    private readonly IApplicationDbContext _context;
    private readonly ILoggedInUserAccessor _loggedInUser;

    public ListMyAppointmentsHandler(IApplicationDbContext context, ILoggedInUserAccessor loggedInUser)
    {
        _context = context;
        _loggedInUser = loggedInUser;
    }
    public async Task<List<AppointmentDto>> Handle(ListMyAppointmentsQuery request, CancellationToken cancellationToken)
    {
        var userId = _loggedInUser.LoggedInUser?.UserId ?? throw new NotFoundException("User not found");


        var appointments = await _context.Appointments
            .Where(a => a.Patient.Id == userId)
            .Select(a => new AppointmentDto(
                               a.Id,
                               a.AppointmentSchedule.AvailableDateTime,
                               new DoctorDto(a.AppointmentSchedule.Doctor.Name, a.AppointmentSchedule.Doctor.CPF.Value, a.AppointmentSchedule.Doctor.CRM, a.AppointmentSchedule.Doctor.Email),
                               new PatientDto(a.Patient.Name, a.Patient.CPF.Value, a.Patient.Email)))
            .ToListAsync(cancellationToken);

          
        return appointments;


    }
}
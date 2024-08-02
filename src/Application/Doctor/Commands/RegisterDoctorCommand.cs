using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Doctor.Dtos;
using Application.User;
using Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Doctor.Command;
public class RegisterDoctorCommand : IRequest<DoctorDto>
{
    public RegisterDoctorCommand(string name, string crm)
    {
        Name = name;
        CRM = crm;
    }

    public string Name { get; set; }
    public string CRM { get; set; }
}


public class RegisterDoctorCommandHandler : IRequestHandler<RegisterDoctorCommand, DoctorDto>
{
    private readonly IApplicationDbContext _context;
    private ILoggedInUserAccessor _loggedInUserAccessor;

    public RegisterDoctorCommandHandler(IApplicationDbContext context, ILoggedInUserAccessor loggedInUserAccessor)
    {
        _context = context;
        _loggedInUserAccessor = loggedInUserAccessor;
    }

    public async Task<DoctorDto> Handle(RegisterDoctorCommand request, CancellationToken cancellationToken)
    {
        var userId = _loggedInUserAccessor.LoggedInUser?.UserId ?? throw new NotFoundException("User not found");
        
        var doctor = await _context.Doctors.FindAsync(userId);

        if(doctor != null)
        {
            throw new DomainException("Doctor already exists");
        }
        
        doctor = new Domain.Entities.Doctor
        (
            id: userId,
            name : request.Name,
            cRM: request.CRM
        );

        _context.Doctors.Add(doctor);
        await _context.SaveChangesAsync(cancellationToken);

        return new DoctorDto(doctor.Name, doctor.CRM);
    }
}
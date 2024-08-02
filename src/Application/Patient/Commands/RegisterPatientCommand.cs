using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Patient.Dtos;
using Application.User;
using Domain.Exceptions;
using Domain.ValueObjects;
using MediatR;

namespace Application.Doctor.Command;
public class RegisterPatientCommand : IRequest<PatientDto>
{
    public RegisterPatientCommand(string name, string cpf)
    {
        Name = name;
        CPF = cpf;
    }

    public string Name { get; set; }
    public string CPF { get; set; }
}


public class RegisterPatientCommandHandler : IRequestHandler<RegisterPatientCommand, PatientDto>
{
    private readonly IApplicationDbContext _context;
    private ILoggedInUserAccessor _loggedInUserAccessor;

    public RegisterPatientCommandHandler(IApplicationDbContext context, ILoggedInUserAccessor loggedInUserAccessor)
    {
        _context = context;
        _loggedInUserAccessor = loggedInUserAccessor;
    }

    public async Task<PatientDto> Handle(RegisterPatientCommand request, CancellationToken cancellationToken)
    {
        var userId = _loggedInUserAccessor.LoggedInUser?.UserId ?? throw new NotFoundException("User not found");

        var patient = await _context.Patients.FindAsync(userId);

        if (patient != null)
        {
            throw new DomainException("Patient already exists");
        }

        patient = new Domain.Entities.Patient
        (
            id: userId,
            name : request.Name,
            cpf: Cpf.From(request.CPF),
            email: _loggedInUserAccessor.LoggedInUser.Email
        );

        _context.Patients.Add(patient);
        await _context.SaveChangesAsync(cancellationToken);

        return new PatientDto(patient.Name, patient.CPF.Value, patient.Email);
    }
}
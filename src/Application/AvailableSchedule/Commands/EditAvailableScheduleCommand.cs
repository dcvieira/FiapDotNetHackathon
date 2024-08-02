using Application.AvailableSchedule.Dtos;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Doctor.Dtos;
using Application.User;
using MediatR;

namespace Application.AvailableSchedule.Commands;


public class EditAvailableScheduleCommand : IRequest<AvailableScheduleDto>
{
    public Guid AvailableScheduleId { get; set; }
    public DateTime AvailableDateTime { get; set; }
}

public class EditAvailableScheduleCommandHandler : IRequestHandler<EditAvailableScheduleCommand, AvailableScheduleDto>
{

    private readonly IApplicationDbContext _context;
    private ILoggedInUserAccessor _loggedInUserAccessor;

    public EditAvailableScheduleCommandHandler(IApplicationDbContext context, ILoggedInUserAccessor loggedInUserAccessor)
    {
        _context = context;
        _loggedInUserAccessor = loggedInUserAccessor;
    }

    public async Task<AvailableScheduleDto> Handle(EditAvailableScheduleCommand request, CancellationToken cancellationToken)
    {
        var userId = _loggedInUserAccessor.LoggedInUser?.UserId ?? throw new NotFoundException("User not found");

        var doctor = await _context.Doctors.FindAsync(userId);

        if (doctor == null)
        {
            throw new NotFoundException("Doctor not found");
        }

        var schedule = await _context.AvailableSchedules.FindAsync(request.AvailableScheduleId);

        if (schedule == null)
        {
            throw new NotFoundException("Schedule not found");
        }

        schedule.AvailableDateTime = request.AvailableDateTime;

        await _context.SaveChangesAsync(cancellationToken);

        return new AvailableScheduleDto(
            schedule.Id,
            schedule.AvailableDateTime,
            schedule.IsAvailable,
            new DoctorDto(doctor.Name, doctor.CPF.Value, doctor.CRM, doctor.Email)
            );
    }
}
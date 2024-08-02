using Application.AvailableSchedule.Dtos;
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

namespace Application.AvailableSchedule.Commands
{
    public class AddAvailableScheduleCommand : IRequest<AvailableScheduleDto>
    {
        public DateTime AvailableDateTime { get; set; }
    }

    public class AddAvailableScheduleCommandHandler : IRequestHandler<AddAvailableScheduleCommand, AvailableScheduleDto>
    {

        private readonly IApplicationDbContext _context;
        private ILoggedInUserAccessor _loggedInUserAccessor;

        public AddAvailableScheduleCommandHandler(IApplicationDbContext context, ILoggedInUserAccessor loggedInUserAccessor)
        {
            _context = context;
            _loggedInUserAccessor = loggedInUserAccessor;
        }

        public async Task<AvailableScheduleDto> Handle(AddAvailableScheduleCommand request, CancellationToken cancellationToken)
        {
            var userId = _loggedInUserAccessor.LoggedInUser?.UserId ?? throw new NotFoundException("User not found");

            var doctor = await _context.Doctors.FindAsync(userId);

            if (doctor == null)
            {
                throw new NotFoundException("Doctor not found");
            }

            var schedule = new Domain.Entities.AvailableSchedule(
                availableDateTime: request.AvailableDateTime,
                doctor: doctor
                );

            _context.AvailableSchedules.Add(schedule);
            await _context.SaveChangesAsync(cancellationToken);

            return new AvailableScheduleDto(
                schedule.Id,
                schedule.AvailableDateTime,
                schedule.IsAvailable,
                new DoctorDto(doctor.Name, doctor.CPF.Value, doctor.CRM, doctor.Email)
                );
        }
    }
}

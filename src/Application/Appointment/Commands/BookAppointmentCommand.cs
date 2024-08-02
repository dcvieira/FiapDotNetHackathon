using Application.Appointment.Dtos;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Doctor.Dtos;
using Application.Patient.Dtos;
using Application.User;
using Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Appointment.Commands
{
    public  class BookAppointmentCommand : IRequest<AppointmentDto>
    {
        public Guid AvailableScheduleId { get; set; }
    }

    public class BookAppointmentCommandHandler : IRequestHandler<BookAppointmentCommand, AppointmentDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILoggedInUserAccessor _loggedInUser;
        private readonly IEmailSender _emailSender;

        public BookAppointmentCommandHandler(IApplicationDbContext context, ILoggedInUserAccessor loggedInUser)
        {
            _context = context;
            _loggedInUser = loggedInUser;
        }

        public async Task<AppointmentDto> Handle(BookAppointmentCommand request, CancellationToken cancellationToken)
        {
            var userId = _loggedInUser.LoggedInUser?.UserId ?? throw new NotFoundException("User not found");

            var patient = await _context.Patients.FindAsync(userId);

            if (patient == null)
            {
                throw new NotFoundException(nameof(Patient), userId);
            }

            var availableSchedule = await _context.AvailableSchedules.FindAsync(request.AvailableScheduleId);

            if (availableSchedule == null)
            {
                throw new NotFoundException(nameof(AvailableSchedule), request.AvailableScheduleId);
            }

            if (!availableSchedule.IsAvailable)
            {
                throw new DomainException("Schedule is no more available");
            }

            availableSchedule.IsAvailable = false;
            _context.AvailableSchedules.Update(availableSchedule);


            var appointment = new Domain.Entities.Appointment(
                    appointmentSchedule: availableSchedule,
                    patient: patient

                );


            _context.Appointments.Add(appointment);

            string formato = "dddd, dd 'de' MMMM 'de' yyyy 'às' HH:mm";

            var emailTemplate = new StringBuilder();
                    emailTemplate.AppendLine($"<p>Olá, Dr.{availableSchedule.Doctor.Name}!</p>");
            emailTemplate.AppendLine($"<p>Você tem uma nova consulta marcada!</p>");
            emailTemplate.AppendLine($"<p>Paciente: {patient.Name}</p>");
            emailTemplate.AppendLine($"<p>Data e horário: {availableSchedule.AvailableDateTime.ToString(formato)}</p>");
            emailTemplate.AppendLine($"<p></p>");

            await _emailSender.SendEmailAsync(availableSchedule.Doctor.Email, "Health & Med - Nova consulta agendada", "Your appointment has been booked");

            await _context.SaveChangesAsync(cancellationToken);

            return new AppointmentDto(appointment.Id, appointment.AppointmentSchedule.AvailableDateTime,
                new DoctorDto(availableSchedule.Doctor.Name, availableSchedule.Doctor.CPF.Value, availableSchedule.Doctor.CRM, availableSchedule.Doctor.Email), 
                new PatientDto(patient.Name, patient.CPF.Value, patient.Email));
        }
    }
}


//Título do e-mail:
//”Health & Med - Nova consulta agendada”
//Corpo do e-mail:
//”Olá, Dr. {nome_do_médico}!
//Você tem uma nova consulta marcada!
//Paciente: { nome_do_paciente}.
//Data e horário: { data}às {horário_agendado}.”


using Application.Doctor.Dtos;
using Application.Patient.Dtos;

namespace Application.Appointment.Dtos;

public record  AppointmentDto(Guid Id, DateTime AppointmentDateTime, DoctorDto Doctor, PatientDto patient);
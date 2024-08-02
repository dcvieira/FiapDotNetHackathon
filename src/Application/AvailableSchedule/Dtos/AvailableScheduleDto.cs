using Application.Doctor.Dtos;

namespace Application.AvailableSchedule.Dtos;

public  record AvailableScheduleDto(Guid Id, DateTime AvailableDateTime, bool IsAvailable, DoctorDto doctor);

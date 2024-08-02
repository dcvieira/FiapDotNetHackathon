using Domain.Common;

namespace Domain.Entities;


public class Appointment : BaseEntity
{

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Appointment()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        
    }
    public Appointment(AvailableSchedule appointmentSchedule,  Patient patient)
    {
        Id = Guid.NewGuid();
        AppointmentSchedule = appointmentSchedule;
        Patient = patient;
    }

    public AvailableSchedule AppointmentSchedule { get; set; }
    public Patient Patient { get; set; }
}

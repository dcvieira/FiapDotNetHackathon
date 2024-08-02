using Domain.Common;

namespace Domain.Entities;


public class Appointment : BaseEntity
{
    public Guid DoctorId { get; set; }
    public Guid PatientId { get; set; }
    public DateTime AppointmentDateTime { get; set; }

    public Doctor Doctor { get; set; }
    public Patient Patient { get; set; }
}

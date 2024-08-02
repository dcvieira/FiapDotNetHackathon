using Domain.Common;

namespace Domain.Entities;


public class AvailableSchedule : BaseEntity 
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private AvailableSchedule()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }
    public AvailableSchedule(DateTime availableDateTime, Doctor doctor)
    {
        Id = Guid.NewGuid();
        AvailableDateTime = availableDateTime;
        IsAvailable = true;
        Doctor = doctor;
    }

    public DateTime AvailableDateTime { get; set; }
    public bool IsAvailable { get; set; }
    public Doctor Doctor { get; set; }

}
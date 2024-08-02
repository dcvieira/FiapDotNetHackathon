using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Persistence.Configurations;

public class AvailableScheduleConfiguration : BaseEntityConfiguration<AvailableSchedule>
{
    public override void ConfigureCore(EntityTypeBuilder<AvailableSchedule> builder)
    {
        builder.Property(x => x.DoctorId)
            .IsRequired();

        builder.Property(s => s.AvailableDateTime)
            .IsRequired();

        builder.Property(s => s.IsAvailable)
           .IsRequired();

        //builder.HasOne(s => s.Doctor)
        // .WithMany(d => d.AvailableSchedules)
        // .HasForeignKey(s => s.DoctorId);
    }
}
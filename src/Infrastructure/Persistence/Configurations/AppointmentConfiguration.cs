using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class AppointmentConfiguration : BaseEntityConfiguration<Appointment>
{
    public override void ConfigureCore(EntityTypeBuilder<Appointment> builder)
    {
     

        builder.HasOne(x => x.AppointmentSchedule)
                .WithMany()
                .IsRequired();

        builder.HasOne(x => x.Patient)
            .WithMany()
            .IsRequired();

        builder.Navigation(x => x.AppointmentSchedule).AutoInclude();
        builder.Navigation(x => x.Patient).AutoInclude();
    }
}


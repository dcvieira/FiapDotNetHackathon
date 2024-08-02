using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations;

public class DoctorConfiguration : BaseEntityConfiguration<Doctor>
{
    public override void ConfigureCore(EntityTypeBuilder<Doctor> builder)
    {

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.CRM)
            .HasMaxLength(20)
            .IsRequired();

        //builder.HasMany(d => d.AvailableSchedules)
        //   .WithOne(s => s.Doctor)
        //   .HasForeignKey(s => s.DoctorId);

        //builder.HasMany(d => d.Appointments)
        //    .WithOne(a => a.Doctor)
        //    .HasForeignKey(a => a.DoctorId);
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations;
    public class AppointmentConfiguration : BaseEntityConfiguration<Appointment>
{
        public override void ConfigureCore(EntityTypeBuilder<Appointment> builder)
    {
            builder.Property(x => x.AppointmentDateTime)
                .IsRequired();

        builder.Property(a => a.DoctorId)
            .IsRequired();

        builder.Property(a => a.PatientId)
          .IsRequired();

        //builder.HasOne(x => x.Doctor)
        //        .WithMany()
        //        .HasForeignKey(x => x.DoctorId);
        //    builder.HasOne(x => x.Patient)
        //        .WithMany()
        //        .HasForeignKey(x => x.PatientId);
        }
    }


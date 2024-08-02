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

        builder.Property(x => x.Email)
            .HasMaxLength(100)
            .IsRequired();

        builder.OwnsOne(a => a.CPF)
           .Property(a => a.Value)
           .HasMaxLength(11)
           .IsRequired();
    }
}

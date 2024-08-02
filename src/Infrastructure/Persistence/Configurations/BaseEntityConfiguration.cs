using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations;

public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        ConfigureCore(builder);


        builder.HasKey(x => x.Id);
        builder.Property(x => x.CreatedBy)
            .HasMaxLength(100);
        builder.Property(x => x.ModifiedBy)
          .HasMaxLength(100);
        builder.Property(x => x.CreationDate);
        builder.Property(x => x.ModificationDate);
    }

    public abstract void ConfigureCore(EntityTypeBuilder<T> builder);

}
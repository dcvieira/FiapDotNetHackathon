
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces;
public interface IApplicationDbContext
{
    //public DbSet<Domain.Entities.Appointment> Appointments { get; }
    public DbSet<Domain.Entities.Doctor> Doctors { get; }
    public DbSet<Domain.Entities.Patient> Patients { get; }
    //public DbSet<Domain.Entities.AvailableSchedule> AvailableSchedules { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}


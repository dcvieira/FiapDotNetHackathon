using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;


namespace Infrastructure.Persistence;


public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AvailableSchedule> AvailableSchedules { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new DoctorConfiguration());
        builder.ApplyConfiguration(new PatientConfiguration());
        builder.ApplyConfiguration(new AvailableScheduleConfiguration());
        builder.ApplyConfiguration(new AppointmentConfiguration());

        base.OnModelCreating(builder);
    }
}
using Domain.Entities;
using Domain.ValueObjects;
using FluentAssertions;

namespace UnitTests.Entities;
public class AppointmentTests
{
    [Fact]
    public void Constructor_ShouldInitializeProperties()
    {
        // Arrange
        var availableSchedule = new AvailableSchedule(DateTime.Now, new Doctor(Guid.NewGuid(), "Dr. John Doe", Cpf.From("88279553053"), "12345", "johndoe@example.com"));
        var patient = new Patient(Guid.NewGuid(), "John Doe", Cpf.From("88279553053"), "johndoe@example.com");

        // Act
        var appointment = new Appointment(availableSchedule, patient);

        // Assert
        appointment.Id.Should().NotBe(Guid.Empty);
        appointment.AppointmentSchedule.Should().Be(availableSchedule);
        appointment.Patient.Should().Be(patient);
    }

    [Fact]
    public void AppointmentSchedule_ShouldSetAndGetProperly()
    {
        // Arrange
        var appointment = new Appointment(new AvailableSchedule(DateTime.Now, new Doctor(Guid.NewGuid(), "Dr. John Doe", Cpf.From("88279553053"), "12345", "johndoe@example.com")), new Patient(Guid.NewGuid(), "John Doe", Cpf.From("88279553053"), "johndoe@example.com"));
        var newSchedule = new AvailableSchedule(DateTime.Now.AddDays(1), new Doctor(Guid.NewGuid(), "Dr. Jane Doe", Cpf.From("88279553053"), "54321", "janedoe@example.com"));

        // Act
        appointment.AppointmentSchedule = newSchedule;

        // Assert
        appointment.AppointmentSchedule.Should().Be(newSchedule);
    }

    [Fact]
    public void Patient_ShouldSetAndGetProperly()
    {
        // Arrange
        var appointment = new Appointment(new AvailableSchedule(DateTime.Now, new Doctor(Guid.NewGuid(), "Dr. John Doe", Cpf.From("88279553053"), "12345", "johndoe@example.com")), new Patient(Guid.NewGuid(), "John Doe", Cpf.From("88279553053"), "johndoe@example.com"));
        var newPatient = new Patient(Guid.NewGuid(), "Jane Doe", Cpf.From("88279553053"), "janedoe@example.com");

        // Act
        appointment.Patient = newPatient;

        // Assert
        appointment.Patient.Should().Be(newPatient);
    }
}

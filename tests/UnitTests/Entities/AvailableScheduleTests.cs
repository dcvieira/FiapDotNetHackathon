using Domain.Entities;
using Domain.ValueObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Entities;

public class AvailableScheduleTests
{
    [Fact]
    public void Constructor_ShouldInitializeProperties()
    {
        // Arrange
        var availableDateTime = DateTime.Now;
        var doctor = new Doctor(Guid.NewGuid(), "Dr. John Doe", Cpf.From("88279553053"), "12345", "johndoe@example.com");

        // Act
        var availableSchedule = new AvailableSchedule(availableDateTime, doctor);

        // Assert
        availableSchedule.Id.Should().NotBe(Guid.Empty);
        availableSchedule.AvailableDateTime.Should().Be(availableDateTime);
        availableSchedule.IsAvailable.Should().BeTrue();
        availableSchedule.Doctor.Should().Be(doctor);
    }

    [Fact]
    public void AvailableDateTime_ShouldSetAndGetProperly()
    {
        // Arrange
        var availableSchedule = new AvailableSchedule(DateTime.Now, new Doctor(Guid.NewGuid(), "Dr. John Doe", Cpf.From("88279553053"), "12345", "johndoe@example.com"));
        var newDateTime = DateTime.Now.AddDays(1);

        // Act
        availableSchedule.AvailableDateTime = newDateTime;

        // Assert
        availableSchedule.AvailableDateTime.Should().Be(newDateTime);
    }

    [Fact]
    public void IsAvailable_ShouldSetAndGetProperly()
    {
        // Arrange
        var availableSchedule = new AvailableSchedule(DateTime.Now, new Doctor(Guid.NewGuid(), "Dr. John Doe", Cpf.From("88279553053"), "12345", "johndoe@example.com"));
        var newAvailability = false;

        // Act
        availableSchedule.IsAvailable = newAvailability;

        // Assert
        availableSchedule.IsAvailable.Should().Be(newAvailability);
    }

    [Fact]
    public void Doctor_ShouldSetAndGetProperly()
    {
        // Arrange
        var availableSchedule = new AvailableSchedule(DateTime.Now, new Doctor(Guid.NewGuid(), "Dr. John Doe", Cpf.From("88279553053"), "12345", "johndoe@example.com"));
        var newDoctor = new Doctor(Guid.NewGuid(), "Dr. Jane Doe", Cpf.From("49503399076"), "54321", "janedoe@example.com");

        // Act
        availableSchedule.Doctor = newDoctor;

        // Assert
        availableSchedule.Doctor.Should().Be(newDoctor);
    }
}
using Domain.Entities;
using Domain.ValueObjects;
using FluentAssertions;

namespace UnitTests.Entities;
public class DoctorTests
{
    [Fact]
    public void Constructor_ShouldInitializeProperties()
    {
        // Arrange
        var id = Guid.NewGuid();
        var name = "Dr. John Doe";
        var cpf = Cpf.From("88279553053");
        var crm = "12345";
        var email = "johndoe@example.com";

        // Act
        var doctor = new Doctor(id, name, cpf, crm, email);

        // Assert
        doctor.Id.Should().Be(id);
        doctor.Name.Should().Be(name);
        doctor.CPF.Should().Be(cpf);
        doctor.CRM.Should().Be(crm);
        doctor.Email.Should().Be(email);
    }

    [Fact]
    public void Name_ShouldSetAndGetProperly()
    {
        // Arrange
        var doctor = new Doctor(Guid.NewGuid(), "Dr. John Doe", Cpf.From("88279553053"), "12345", "johndoe@example.com");
        var newName = "Dr. Jane Doe";

        // Act
        doctor.Name = newName;

        // Assert
        doctor.Name.Should().Be(newName);
    }

    [Fact]
    public void CPF_ShouldSetAndGetProperly()
    {
        // Arrange
        var doctor = new Doctor(Guid.NewGuid(), "Dr. John Doe",  Cpf.From("88279553053"), "12345", "johndoe@example.com");
        var newCpf =  Cpf.From("28599364081");

        // Act
        doctor.CPF = newCpf;

        // Assert
        doctor.CPF.Should().Be(newCpf);
    }

    [Fact]
    public void CRM_ShouldSetAndGetProperly()
    {
        // Arrange
        var doctor = new Doctor(Guid.NewGuid(), "Dr. John Doe",  Cpf.From("88279553053"), "12345", "johndoe@example.com");
        var newCrm = "54321";

        // Act
        doctor.CRM = newCrm;

        // Assert
        doctor.CRM.Should().Be(newCrm);
    }

    [Fact]
    public void Email_ShouldSetAndGetProperly()
    {
        // Arrange
        var doctor = new Doctor(Guid.NewGuid(), "Dr. John Doe",  Cpf.From("88279553053"), "12345", "johndoe@example.com");
        var newEmail = "janedoe@example.com";

        // Act
        doctor.Email = newEmail;

        // Assert
        doctor.Email.Should().Be(newEmail);
    }
}

using Domain.Entities;
using Domain.ValueObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Entities;



public class PatientTests
{
    [Fact]
    public void Constructor_ShouldInitializeProperties()
    {
        // Arrange
        var id = Guid.NewGuid();
        var name = "John Doe";
        var cpf = Cpf.From("88279553053"); // Supondo que Cpf tem um construtor que aceita uma string
        var email = "johndoe@example.com";

        // Act
        var patient = new Patient(id, name, cpf, email);

        // Assert
        patient.Id.Should().Be(id);
        patient.Name.Should().Be(name);
        patient.CPF.Should().Be(cpf);
        patient.Email.Should().Be(email);
    }

    [Fact]
    public void Name_ShouldSetAndGetProperly()
    {
        // Arrange
        var patient = new Patient(Guid.NewGuid(), "John Doe", Cpf.From("88279553053"), "johndoe@example.com");
        var newName = "Jane Doe";

        // Act
        patient.Name = newName;

        // Assert
        patient.Name.Should().Be(newName);
    }

    [Fact]
    public void CPF_ShouldSetAndGetProperly()
    {
        // Arrange
        var patient = new Patient(Guid.NewGuid(), "John Doe", Cpf.From("88279553053"), "johndoe@example.com");
        var newCpf = Cpf.From("49503399076");

        // Act
        patient.CPF = newCpf;

        // Assert
        patient.CPF.Should().Be(newCpf);
    }

    [Fact]
    public void Email_ShouldSetAndGetProperly()
    {
        // Arrange
        var patient = new Patient(Guid.NewGuid(), "John Doe", Cpf.From("88279553053"), "johndoe@example.com");
        var newEmail = "janedoe@example.com";

        // Act
        patient.Email = newEmail;

        // Assert
        patient.Email.Should().Be(newEmail);
    }
}
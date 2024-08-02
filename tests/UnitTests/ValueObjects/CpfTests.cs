using Domain.Exceptions;
using Domain.ValueObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.ValueObjects;


public class CpfTests
{
    [Theory]
    [InlineData("88314884065")]
    [InlineData("34808791013")]
    [InlineData("42104065038")]
    [InlineData("61655832026")]
    public void ShouldCreate_WhenValid(string cpf)
    {
        // Act
        var result = Cpf.From(cpf);

        // Assert
        result.Value.Should().Be(cpf);
    }

    [Theory]
    [InlineData("88314824065")]
    [InlineData("34808721013")]
    [InlineData("42104025038")]
    [InlineData("61655822026")]
    public void ShouldThrowException_WhenInvalid(string cpf)
    {
        // Act
        Action act = () => Cpf.From(cpf);

        // Assert
        act.Should().Throw<DomainException>();
    }
}
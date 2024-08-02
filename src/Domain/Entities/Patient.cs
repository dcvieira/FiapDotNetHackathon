using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities;


public class Patient : BaseEntity
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Patient()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        
    }
    public Patient(Guid id, string name, Cpf cpf, string email)
    {
        Id = id;
        Name = name;
        CPF = cpf;
        Email = email;
    }

    public string Name { get; set; }
    public Cpf CPF { get; set; }
    public string Email { get; set; }

}
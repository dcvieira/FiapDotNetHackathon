using Domain.Common;
using Domain.ValueObjects;
namespace Domain.Entities;


public class Doctor : BaseEntity
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Doctor()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }
    public Doctor(Guid id, string name, Cpf cpf, string cRM, string email)
    {
        Id = id;
        Name = name;
        CPF = cpf;
        CRM = cRM;
        Email = email;
    }

    public string Name { get; set; }
    public Cpf CPF { get; set; }
    public string CRM { get; set; }
    public string Email { get; set; }

}
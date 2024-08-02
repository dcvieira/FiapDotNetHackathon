using Domain.Common;

namespace Domain.Entities;


public class Patient : BaseEntity
{
    public Patient(Guid id, string name, string cPF)
    {
        Id = id;
        Name = name;
        CPF = cPF;
    }

    public string Name { get; set; }
    public string CPF { get; set; }

}
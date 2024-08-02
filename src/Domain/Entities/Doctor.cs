using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;


public class Doctor : BaseEntity
{
    public Doctor(Guid id, string name, string cRM)
    {
        Id = id;
        Name = name;
        CRM = cRM;
    }

    public string Name { get; set; }
    public string CRM { get; set; }

}
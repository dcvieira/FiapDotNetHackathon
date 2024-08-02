
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModificationDate { get; set; }

        public string? ModifiedBy { get; set; }

    }
}

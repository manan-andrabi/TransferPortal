using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferPortal.Domain.Entities
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public int Gender { get; set; }

        public string Designation { get; set; } = null!;

        public int FromDist { get; set; }

        public int ToDist { get; set; }
        public string CreatedOn { get; set; } = null!;
    }
}

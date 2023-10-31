using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace TransferPortal.Application.Abstraction.RRModal
{
    public class TeacherRequest
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
         
        [StringLength(10),MinLength(10, ErrorMessage = "Phone number must be 10 digits long.")]
        public string Phone { get; set; } = null!;

        [Required]
        public int Gender { get; set; }

        [Required]
        public string Designation { get; set; } = null!;

        [Required]
        public int FromDist { get; set; }

        [Required]
        public int ToDist { get; set; }
       
    }
    public class TeacherResponse : TeacherRequest
    {
        public Guid Id { get; set; }
        public string CreatedOn { get; set; } = null!;
    }
    public class TransferList
    {
        public Guid Match_Id { get; set; }
        public Guid MatchWith_Id { get; set; }
        public string Match { get; set; } = null!;
        public string MatchWith { get; set; } = null!;
        public string Match_Contact { get; set; } = null!;
        public string MatchWith_Contact { get; set; } = null!;
        public int FromDist { get; set; }  
        public int ToDist { get; set; }
        public int MatchWith_FromDist { get; set; }
        public int MatchWith_ToDist { get; set; }
        public string Match_Created { get; set; } = null!;
        public string MatchWith_Created { get; set; } = null!;
        public string Match_Designation { get; set; } = null!;
        public string MatchWith_Designation { get; set; } = null!;
        public int Match_Gender { get; set; } 
        public int MatchWith_Gender { get; set; } 

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MondayReporting2.Models
{
    public class CT_Users
    {
        public int id { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        [Display(Name = "Last access")]
        public DateTime? LastAccess { get; set; }
        public bool Status { get; set; }


        public int RoleId { get; set; }
        public CT_Roles Role { get; set; }
    }
}

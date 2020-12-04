using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MondayReporting2.Models.MyModels
{
    public class MyRoles
    {
        [Required]
        public string id { get; set; }
        [Required]
        public string Role { get; set; }

        public string Comment { get; set; }
    }
}

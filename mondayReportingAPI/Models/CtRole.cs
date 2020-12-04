using System;
using System.Collections.Generic;

#nullable disable

namespace mondayReportingAPI.Models
{
    public partial class CtRole
    {
        public CtRole()
        {
            CtUsers = new HashSet<CtUser>();
        }

        public int Id { get; set; }
        public string Role { get; set; }
        public string Comment { get; set; }

        public virtual ICollection<CtUser> CtUsers { get; set; }
    }
}

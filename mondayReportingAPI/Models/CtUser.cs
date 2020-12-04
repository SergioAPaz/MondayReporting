using System;
using System.Collections.Generic;

#nullable disable

namespace mondayReportingAPI.Models
{
    public partial class CtUser
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public DateTime? LastAccess { get; set; }
        public bool Status { get; set; }
        public int RoleId { get; set; }

        public virtual CtRole Role { get; set; }
    }
}

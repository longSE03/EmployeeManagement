using System;
using System.Collections.Generic;

namespace EmployeeManagement.DataAccess.Entities
{
    public partial class Claim
    {
        public Claim()
        {
            RoleClaims = new HashSet<RoleClaim>();
        }

        public int ClaimId { get; set; }
        public string? ClaimName { get; set; }

        public virtual ICollection<RoleClaim> RoleClaims { get; set; }
    }
}

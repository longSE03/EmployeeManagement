using System;
using System.Collections.Generic;

namespace EmployeeManagement.DataAccess.Entities
{
    public partial class RoleClaim
    {
        public int RoleClaims { get; set; }
        public int RoleId { get; set; }
        public int ClaimId { get; set; }

        public virtual Claim Claim { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
    }
}

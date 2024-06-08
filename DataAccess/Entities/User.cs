using System;
using System.Collections.Generic;

namespace EmployeeManagement.DataAccess.Entities
{
    public partial class User
    {
        public User()
        {
            ActualSalaries = new HashSet<ActualSalary>();
            RefreshTokens = new HashSet<RefreshToken>();
            Submissions = new HashSet<Submission>();
        }

        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public double? ContractSalary { get; set; }
        public int? DaysOff { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? TokenCreated { get; set; }
        public DateTime? TokenExpires { get; set; }
        public bool Status { get; set; }
        public int? RoleId { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<ActualSalary> ActualSalaries { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
        public virtual ICollection<Submission> Submissions { get; set; }
    }
}

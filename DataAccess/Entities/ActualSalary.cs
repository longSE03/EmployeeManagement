using System;
using System.Collections.Generic;

namespace EmployeeManagement.DataAccess.Entities
{
    public partial class ActualSalary
    {
        public int ActualSalaryId { get; set; }
        public double ContractSalary { get; set; }
        public double FinalSalary { get; set; }
        public int DaysOff { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}

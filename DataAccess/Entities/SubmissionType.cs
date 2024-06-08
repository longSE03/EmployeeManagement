using System;
using System.Collections.Generic;

namespace EmployeeManagement.DataAccess.Entities
{
    public partial class SubmissionType
    {
        public SubmissionType()
        {
            Submissions = new HashSet<Submission>();
        }

        public int SubmissionTypeId { get; set; }
        public string? SubmissionTypeName { get; set; }

        public virtual ICollection<Submission> Submissions { get; set; }
    }
}

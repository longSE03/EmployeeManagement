using System;
using System.Collections.Generic;

namespace EmployeeManagement.DataAccess.Entities
{
    public partial class Submission
    {
        public Submission()
        {
            AttachedFiles = new HashSet<AttachedFile>();
        }

        public int SubmissionId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime SendDate { get; set; }
        public bool? Status { get; set; }
        public int UserId { get; set; }
        public int SubmissionTypeId { get; set; }

        public virtual SubmissionType SubmissionType { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<AttachedFile> AttachedFiles { get; set; }
    }
}

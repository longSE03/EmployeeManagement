﻿using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.DataAccess.Repositories.Interface
{
    public interface IAttachedFileRepository
    {
        ICollection<AttachedFile> GetAttachedFiles(); // Use AttachedFile instead of Submission
        AttachedFile GetAttachedFile(int id); // Use AttachedFile instead of Submission
        bool AttachedFileExists(int attachedFileId); // Rename to AttachedFileExists
        bool CreateAttachedFile(AttachedFile attachedFile); // Use AttachedFile instead of Submission
        bool UpdateAttachedFile(AttachedFile attachedFile); // Use AttachedFile instead of Submission
        bool DeleteAttachedFile(AttachedFile attachedFile); // Use AttachedFile instead of Submission
        bool Save();

    }
}

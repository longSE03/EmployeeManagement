using EmployeeManagement.DataAccess.DTOs;
using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Services.Interfaces
{
    public interface ISubmissionService
    {
        Submission CreateSubmission(SubmissionDTO dto, IFormFile fileData, int userId);
        Submission GetSubmissionById(int id);
        bool UpdateSubmission(Submission submission);
    }
}

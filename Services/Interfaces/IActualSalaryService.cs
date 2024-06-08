using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IActualSalaryService
    {
        bool CreateActualSalary(ActualSalary actualSalary);
        ActualSalary GetActualSalaryByUserId(int userId);
    }
}

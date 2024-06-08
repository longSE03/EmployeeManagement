using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.DataAccess.Repositories.Interface
{
    public interface IActualSalaryRepository
    {
        ICollection<ActualSalary> GetActualSalarys();
        ActualSalary GetActualSalary(int userId);
        bool ActualSalaryExists(int actualSalaryId);
        bool CreateActualSalary(ActualSalary actualSalary);
        bool UpdateActualSalary(ActualSalary actualSalary);
        bool Save();
    }
}

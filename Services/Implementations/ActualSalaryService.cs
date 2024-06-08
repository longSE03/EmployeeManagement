using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.UnitOfWork;
using EmployeeManagement.Services.Interfaces;

namespace EmployeeManagement.Services.Implementations
{
    public class ActualSalaryService : IActualSalaryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActualSalaryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CreateActualSalary(ActualSalary actualSalary)
        {
            return _unitOfWork.ActualSalaryObj.CreateActualSalary(actualSalary);
        }

        public ActualSalary GetActualSalaryByUserId(int userId)
        {
            return _unitOfWork.ActualSalaryObj.GetActualSalary(userId);
        }
    }
}

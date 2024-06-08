using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.UnitOfWork;
using EmployeeManagement.Services.Interfaces;

namespace EmployeeManagement.Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateRole(IEnumerable<Role> roles)
        {
            await _unitOfWork.RoleObj.AddRangeAsync(roles);

            return true;
        }
    }
}

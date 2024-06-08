using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IRoleService
    {
        Task<bool> CreateRole(IEnumerable<Role> roles);
    }
}

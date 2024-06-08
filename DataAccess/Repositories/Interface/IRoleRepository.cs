using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.DataAccess.Repositories.Interface
{
    public interface IRoleRepository
    {
        Role? Get(int roleId);
        IEnumerable<Role> GetAll();
        Task AddAsync(Role role);
        Task AddRangeAsync(IEnumerable<Role> roles);
    }
}

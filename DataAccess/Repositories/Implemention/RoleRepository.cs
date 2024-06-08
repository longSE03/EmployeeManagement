using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Repositories.Interface;

namespace EmployeeManagement.DataAccess.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly EmployeeManagementContext _context;

        public RoleRepository(EmployeeManagementContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Role role)
        {
            await _context.Set<Role>().AddAsync(role);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<Role> roles)
        {
            foreach (var role in roles)
            {
                await _context.Set<Role>().AddAsync(role);
            }
            await _context.SaveChangesAsync();
        }

        public Role? Get(int roleId)
        {
            return _context.Roles.FirstOrDefault(r => r.RoleId == roleId);
        }

        public IEnumerable<Role> GetAll()
        {
            return _context.Roles.ToList();
        }
    }
}
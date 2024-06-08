using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Repositories.Interface;

namespace EmployeeManagement.DataAccess.Repositories
{
    public class ClaimRepository : IClaimRepository
    {
        private readonly EmployeeManagementContext _context;

        public ClaimRepository(EmployeeManagementContext context)
        {
            _context = context;
        }
        public bool Create(Claim claim)
        {
            _context.Claims.Add(claim);
            return Save();
        }

        public ICollection<Claim> GetAll()
        {
            return _context.Claims.ToList();
        }

        public Claim? Get(int id)
        {
            return _context.Claims.FirstOrDefault(c => c.ClaimId == id);
        }

        public bool Remove(Claim claim)
        {
            _context.Claims.Remove(claim);
            return Save();
        }

        public bool Update(Claim claim)
        {
            _context.Claims.Update(claim);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}

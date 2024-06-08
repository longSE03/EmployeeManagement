using EmployeeManagement.DataAccess.UnitOfWork;
using EmployeeManagement.Services.Interfaces;
using Claim = EmployeeManagement.DataAccess.Entities.Claim;

namespace EmployeeManagement.Services.Implementations
{
    public class ClaimService : IClaimService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClaimService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool CreateClaim(Claim claim)
        {
            return _unitOfWork.ClaimObj.Create(claim);
        }

        public ICollection<Claim> GetAllClaims()
        {
            return _unitOfWork.ClaimObj.GetAll();
        }
        public Claim GetClaim(int id)
        {
            return _unitOfWork.ClaimObj.Get(id);
        }

        public bool RemoveClaim(Claim claim)
        {
            return _unitOfWork.ClaimObj.Remove(claim);
        }

        public bool UpdateClaim(Claim claim)
        {
            return _unitOfWork.ClaimObj.Update(claim);
        }
    }
}
﻿using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.DataAccess.Repositories.Interface
{
    public interface IClaimRepository
    {
        bool Create(Claim claim);
        ICollection<Claim> GetAll();
        Claim? Get(int id);
        bool Remove(Claim claim);
        bool Update(Claim claim);
        bool Save();
    }
}

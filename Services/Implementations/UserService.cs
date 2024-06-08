using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.UnitOfWork;
using EmployeeManagement.Services.Interfaces;

namespace EmployeeManagement.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ICollection<User> GetUsers()
        {
            return _unitOfWork.UserObj.GetUsers();
        }

        public ICollection<User> GetActiveUsers()
        {
            return _unitOfWork.UserObj.GetUsers().Where(u => u.Status).ToList();
        }

        public User GetUser(int id)
        {
            return _unitOfWork.UserObj.GetUser(id);
        }

        public bool CreateUser(User user)
        {
            return _unitOfWork.UserObj.CreateUser(user);
        }

        public bool UpdateUser(User user)
        {
            return _unitOfWork.UserObj.UpdateUser(user);
        }

        public bool DeleteUser(User user)
        {
            return _unitOfWork.UserObj.DeleteUser(user);
        }

        public User GetUserByUserName(string userName)
        {
            
            if(userName != null)
            {
                var user = _unitOfWork.UserObj.GetUser(userName);
                if(user != null)
                {
                    return user;
                } 
            }
            return null;
        }
    }
}

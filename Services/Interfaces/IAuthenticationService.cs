using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IAuthenticationService
    {
        string RefreshToken(string refreshToken);
        RefreshToken GenerateRefreshToken();
        string CreateToken(User user);
        void SetRefreshToken(User user, RefreshToken newRefreshToken);
        string GetUserName();
    }
}

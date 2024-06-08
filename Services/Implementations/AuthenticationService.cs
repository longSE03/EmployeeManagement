using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.UnitOfWork;
using EmployeeManagement.Services.Interfaces;
using Claim = System.Security.Claims.Claim;

namespace EmployeeManagement.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly string _key;
        private readonly string _issuer;
        private readonly string _refreshTokenKey;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public AuthenticationService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            //_key = configuration["Jwt:Key"];
            //_issuer = configuration["Jwt:Issuer"];
            //_refreshTokenKey = configuration["Jwt:RefreshTokenKey"];
            this._configuration = configuration;
            this._httpContextAccessor = httpContextAccessor;
            this._unitOfWork = unitOfWork;
        }

        public RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                RefreshTokenString = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                ExpirationDate = DateTime.Now.AddDays(1),
                CreatedDate = DateTime.Now,
            };

            return refreshToken;
        }

        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.RoleId.ToString()),
                new Claim("UserId", user.UserId.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:Secret").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public void SetRefreshToken(User user, RefreshToken newRefreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.ExpirationDate
            };
            _httpContextAccessor.HttpContext.Response.Cookies.Append("refreshToken", newRefreshToken.RefreshTokenString, cookieOptions);

            user.RefreshToken = newRefreshToken.RefreshTokenString;
            user.TokenCreated = newRefreshToken.CreatedDate;
            user.TokenExpires = newRefreshToken.ExpirationDate;
            _unitOfWork.UserObj.UpdateUser(user);
        }

        public string RefreshToken(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public string GetUserName()
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext != null)
            {
                var tempo = _httpContextAccessor.HttpContext.User;
                result = tempo.FindFirstValue(ClaimTypes.Name);
            }
            return result;
        }
    }
}

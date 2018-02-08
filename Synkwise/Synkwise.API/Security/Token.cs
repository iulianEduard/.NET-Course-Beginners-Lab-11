using Microsoft.IdentityModel.Tokens;
using Synkwise.API.Models.Account;
using Synkwise.BLL.Ports;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Synkwise.API.Security
{
    public class Token
    {
        public static readonly string SECRET = "asdasdasdasdasdadadasdasdasdasdasdasdasd";

        public string GenerateToken(UserDataModel userDataModel)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, userDataModel.Email),
                new Claim(ClaimTypes.Role, userDataModel.Role),
                new Claim(ClaimTypes.Name, userDataModel.UserName),
                new Claim("RoleId", userDataModel.RoleId.ToString()),
                new Claim("ContactId", userDataModel.ContactId.ToString()),
                new Claim("UserId", userDataModel.UserId.ToString()),
                new Claim("WorkingId", userDataModel.WorkingId.ToString()),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddHours(4)).ToUnixTimeSeconds().ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public void ValidateToken(string token)
        {
            SecurityToken securityToken;
            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters();
            var result = new JwtSecurityTokenHandler().ValidateToken(token, tokenValidationParameters, out securityToken);
        }
    }
}

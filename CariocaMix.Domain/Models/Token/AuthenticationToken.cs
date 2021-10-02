using CariocaMix.Domain.Models.User;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CariocaMix.Domain.Models.Token
{
    public class AuthenticationToken
    {
        public const string SECRET = "CARIOCAMIXHAMBURGERIACARIOCA2021";

        public static UserAuthenticateModel GenerateToken(Entities.User user)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(SECRET);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("id", user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMonths(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                UserAuthenticateModel userAuthenticate = (UserAuthenticateModel)user;
                userAuthenticate.Token = tokenHandler.WriteToken(token);
                userAuthenticate.TokenExpires = tokenDescriptor.Expires;

                return userAuthenticate;
            }
            catch
            {
                return null;
            }
        }

        public static bool ValidateTokenUser(string token, long id)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(SECRET);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var accountId = long.Parse(jwtToken.Claims.First(x => x.Type == "id")?.Value);

                return accountId == id;
            }
            catch
            {
                return false;
            }
        }
    }
}

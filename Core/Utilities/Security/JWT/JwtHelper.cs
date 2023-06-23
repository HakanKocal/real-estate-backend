using Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper:ITokenHelper
    {
        public readonly IConfiguration _config;
        public TokenOptions _tokenOptions;
        public JwtHelper(IConfiguration config)
        {
            _config = config;
            _tokenOptions = _config.GetSection("TokenOptions").Get<TokenOptions>();
        }
        
        public string CreateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var jwtSecurtityToken = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                claims: SetClaim(user),
                expires: DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration),
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials

            );
            
            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurtityToken);
            return token;
        }
        private IEnumerable<Claim> SetClaim(User user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("Name", user.FirstName));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim("Id", user.Id.ToString()));
            claims.Add(new Claim("Role",user.Role.Name));
            return claims;
        }
    }
}

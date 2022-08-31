using Manage.Model.DTO.User;
using Manage.Model.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Manage.Common
{
    public class TokenConfiguration
    {
        public IConfiguration _configuration { get; }
        public TokenConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GeneratetokenConfiguration(SeUser user)
        {
            var userClaim = new List<Claim>
            {
                new Claim("username",user.Username),
                new Claim("id",Convert.ToString(user.Id)),
                new Claim("Role",user.Role)
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaims(userClaim);
            var jwtTokenHandle = new JwtSecurityTokenHandler();
            var secretkeyBytes = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretkeyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenConfiguration = jwtTokenHandle.CreateToken(tokenDescription);
            return jwtTokenHandle.WriteToken(tokenConfiguration);
        }
        public string GenerateRefreshToken()
        {
            var random = new byte[64];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);
                return Convert.ToBase64String(random);
            }
        }
        public ClaimsPrincipal DecodetokenConfiguration(string Input)
        {
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var handler = new JwtSecurityTokenHandler();
            var tokenSecure = handler.ReadToken(Input);
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            ClaimsPrincipal claims = handler.ValidateToken(Input, validations, out tokenSecure);
            return claims;
        }
        public TokenDecode TokenInfo(string token)
        {
            TokenDecode tokenDecode = new TokenDecode();
            ClaimsPrincipal claimsPrincipal = DecodetokenConfiguration(token);
            tokenDecode.role = claimsPrincipal.Claims.FirstOrDefault(u => u.Type.Equals("Role")).Value;
            tokenDecode.username = claimsPrincipal.Claims.FirstOrDefault(u => u.Type.Equals("username")).Value;
            tokenDecode.exp = long.Parse(claimsPrincipal.Claims.FirstOrDefault(u => u.Type.Equals("exp")).Value);
            return tokenDecode;
        }
        public BaseResponse CheckToken(TokenDecode token)
        {
            DateTime expTimeConverted = ConvertToDateTime(token.exp);
            if (expTimeConverted < DateTime.UtcNow)
                return Response.TokenExpirationResponse();
            if (token.role != "SuperAdmin")
                return Response.ForbiddenResponse();
            return null;
        }
        private DateTime ConvertToDateTime(long expDate)
        {
            DateTime dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeInterval = dateTimeInterval.AddSeconds(expDate).ToUniversalTime();
            return dateTimeInterval;
        }
        public SeToken GenerateTokens (SeUser seUser)
        {
            SeToken tokens = new SeToken();
            tokens.access_token = GeneratetokenConfiguration(seUser);
            tokens.refresh_token = GenerateRefreshToken();
            return tokens;
        }
    }
}
 
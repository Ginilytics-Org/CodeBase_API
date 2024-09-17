using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Ginilytics.Model.DataModels;
using Ginilytics.Model.ViewModels;
using Ginilytics.Service.Data.Model.Common;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Ginilytics.Service.Services
{
    [ScopedService]
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly AppSettings _appSettings;
        private readonly IAuthRepository _authRepository;
        public JwtAuthenticationManager(IOptions<AppSettings> appSettings, IAuthRepository authRepository)
        {
            _appSettings = appSettings.Value;
            _authRepository = authRepository;
        }
        public string GenerateToken(AuthModel authViewModel)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.JWTSecret);
            var expiryTime = _appSettings.TokenExpiryTime;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, authViewModel.userName),
                    //new Claim(ClaimTypes.Role, authViewModel.role),
                    new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(authViewModel)),
                }),
                Expires = DateTime.UtcNow.AddSeconds(expiryTime),
                Issuer = "https://localhost:3000/",
                Audience = "https://localhost:3000/",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        
    }
}

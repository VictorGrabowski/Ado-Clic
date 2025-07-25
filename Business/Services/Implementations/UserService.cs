﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Business.Mappers;
using Business.Responses;
using Business.Services.Interfaces;
using Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model.Model;

namespace Business.Services.Implementations
{
    public class UserService(IUserRepository repository, IConfiguration config) : IUserService
    {
        private readonly IUserRepository _repository = repository;
        private readonly IConfiguration _config = config;

        public async Task<string?> AuthenticateAsync(string email, string password)
        {
            User? user = await _repository.GetUserByEmailAsync(email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return null; // Authentication failed
            }

            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);

            Claim roleClaim = new(ClaimTypes.Role, user.Role.Name);
            Claim emailClaim = new(ClaimTypes.Email, user.Email);

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity([roleClaim, emailClaim]),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<UserProfileData> GetUserProfileDataByEmailAsync(string email)
        {
            User user = await _repository.GetProfileDataByEmailAsync(email);

            return user.ToProfileData();
        }

        public async Task<List<UserListData>> GetAllUsersAsListDataAsync()
        {
            List<User> users = await _repository.GetAllUsersAsync();

            return users.Select(u => u.ToListData()).ToList();
        }
    }
}

﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using REMOTEMIND_EASY.Core.Application.DTO_S.Authentication;
using REMOTEMIND_EASY.Core.Application.Enums;
using REMOTEMIND_EASY.Core.Application.Interfaces.Services;
using REMOTEMIND_EASY.Core.Application.Wrappers;
using REMOTEMIND_EASY.Core.Domain.Settings;
using REMOTEMIND_EASY.Infrastructure.Identity.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace REMOTEMIND_EASY.Infrastructure.Identity.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JWTSetting _jwtSetting;

        public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JWTSetting> jwtSetting)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSetting = jwtSetting.Value;
        }

        public async Task<Response<AuthenticationResponse>> AuthenticateApiAsync(AuthenticationRequest request)
        {

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                return new Response<AuthenticationResponse>("No hay usuarios con el email");
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                return new Response<AuthenticationResponse>("Hubo un problema de login");

            }

            var listRole = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            AuthenticationResponse response = new();
            response.Id = user.Id;
            response.IsVerified = true;
            response.Email = request.Email;
            response.UserName = user.UserName;
            response.Roles = listRole.ToList();

            var jwtSecurityToken = await GenerateJWToken(user);
            response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            var refreshToken = GenerateRefreshToken();
            response.RefreshToken = refreshToken.Token;

            return new Response<AuthenticationResponse>(response);
        }

        public async Task<Response<string>> RegisterEmployeeAsyncApi(RegisterRequest request)
        {
            var userWithSameUserName = await _userManager.FindByNameAsync(request.UserName);
            if (userWithSameUserName != null)
            {
                return new Response<string>("Ya hay un usuario con el mismo username");
            }

            var user = new ApplicationUser()
            {
                Name = request.Name,
                Identification = request.Identification,
                Email = request.Email,
                UserName = request.UserName,
                EmailConfirmed = true
            };

            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
            if (userWithSameEmail != null)
            {
                return new Response<string>("Ya hay un usuario con el mismo email");
            }

            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.Employee.ToString());
            }

            return new Response<string>(user.Id, message: "Usuario registrado exitosamente");

        }

        public async Task<Response<string>> RegisterEnterpriseAsyncApi(RegisterRequest request)
        {
            var userWithSameUserName = await _userManager.FindByNameAsync(request.UserName);
            if (userWithSameUserName != null)
            {
                return new Response<string>("Ya hay un usuario con el mismo username");
            }

            var user = new ApplicationUser()
            {
                Name = request.Name,
                Identification = request.Identification,
                Email = request.Email,
                UserName = request.UserName,
                EmailConfirmed = false
            };

            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
            if (userWithSameEmail != null)
            {
                return new Response<string>("Ya hay un usuario con el mismo email");
            }

            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.Enterprise.ToString());
            }

            return new Response<string>(user.Id, message: "Usuario registrado exitosamente");

        }

        private async Task<JwtSecurityToken> GenerateJWToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            foreach (var role in roles)
            {
                roleClaims.Add(new Claim("roles", role));
            }


            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("uid",user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmectricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.Key));
            var signingCredetials = new SigningCredentials(symmectricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSetting.Issuer,
                audience: _jwtSetting.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSetting.DurationInMinutes),
                signingCredentials: signingCredetials);

            return jwtSecurityToken;
        }

        public async Task<bool> IsUserRegistered(string userId = " ", string email = " ")
        {
   
                var registered = await _userManager.FindByEmailAsync(email);
              

                var user = await _userManager.FindByIdAsync(userId);
                if (user != null || registered != null)
                {
                    return true;
                }
            

            return false;
        }

        private RefreshToken GenerateRefreshToken()
        {
            return new RefreshToken
            {
                Token = RandomTokenString(),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow
            };
        }

        private string RandomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var ramdomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(ramdomBytes);

            return BitConverter.ToString(ramdomBytes).Replace("-", "");
        }
    }
}

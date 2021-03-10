using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using FestivalProject.BL.Facade;
using FestivalProject.BL.Helpers;
using FestivalProject.BL.Models.UserDto;
using FestivalProject.DAL.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FestivalProject.BL.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly UserFacade _facade;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public UserAuthenticationService(UserFacade facade, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _facade = facade;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public UserDetailAuthenticateDto Authenticate(UserAuthenticateDto model)
        {
            var user = _facade.GetByUsername(model.Username);
            
            // return null if user not found
            if (user == null) return null;
            if (user.Password != model.Password) return null;
            


            // authentication successful so generate jwt token
            var token = generateJwtToken(user);
            var authenticatedUser = _mapper.Map<UserDetailAuthenticateDto>(user);
            authenticatedUser.Token = token;
            return authenticatedUser;
        }

        private string generateJwtToken(UserDetailDto user)
        {
            // generate token that is valid for 30 minutes
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

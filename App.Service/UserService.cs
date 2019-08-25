using App.Common.Exceptions;
using App.Common.Helpers;
using App.Data.Infrastructure;
using App.Data.Repositories;
using App.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace App.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOptions<Settings> _options;

        public UserService(IUserRepository repository, IUnitOfWork unitOfWork, IOptions<Settings> options)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _options = options;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var filter = new ExpressionFilterDefinition<User>(u => u.Username == username);
            var user = await _repository.GetFirstByFilter(filter);
            if (user == null)
                throw new BadRequestException("usernama/password aren't rigth");

            if (string.IsNullOrWhiteSpace(password) || !user.Password.VerifyWithBCrypt(password))
                throw new BadRequestException("usernama/password aren't rigth");

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;
        }

       

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _repository.GetAll();
        }

        public async Task<User> Register(User user)
        {
            var username = user.Username.Trim();
            var filter = new ExpressionFilterDefinition<User>(u => u.Username == username);
            var valid = await _repository.GetFirstByFilter(filter);
            if (valid != null)
                throw new BadRequestException("The username is already in use");

            string password = user.Password.Trim().WithBCrypt();
            user.Password = password;
            _repository.Add(user);
            await _unitOfWork.Commit();
            return user;                                  
        }
    }

    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetUsers();
        Task<User> Register(User user);
    }
}

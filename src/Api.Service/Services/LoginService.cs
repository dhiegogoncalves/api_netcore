using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;

namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _repository;
        private IPasswordHasher _passwordHasher;

        public LoginService(IUserRepository repository, IPasswordHasher passwordHasher)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
        }

        public async Task<object> FindByLogin(UserEntity user)
        {
            if (user != null && !string.IsNullOrWhiteSpace(user.Email) && !string.IsNullOrWhiteSpace(user.Password))
            {
                var userDb = await _repository.FindByLogin(user.Email, user.Password);
                var (Verified, NeedsUpgrade) = _passwordHasher.Check(userDb.Password, user.Password);
                if (Verified)
                {
                    return user;
                }
            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;
        private IPasswordHasher _passwordHasher;

        public UserService(IUserRepository repository, IPasswordHasher passwordHasher)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<UserEntity> Post(UserEntity user)
        {
            user.Password = PasswordEncryption(user.Password);
            user = await _repository.InsertAsync(user);
            user.Password = null;
            return user;
        }

        private string PasswordEncryption(string password)
        {
            return _passwordHasher.Hash(password);
        }

        public async Task<UserEntity> Put(UserEntity user)
        {
            return await _repository.Update(user);
        }
    }
}

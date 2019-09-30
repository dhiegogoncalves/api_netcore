using System.Threading.Tasks;
using Api.Domain.Dtos;
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

        public async Task<object> FindByLogin(LoginDto loginDto)
        {
            if (loginDto != null && !string.IsNullOrWhiteSpace(loginDto.Email) && !string.IsNullOrWhiteSpace(loginDto.Password))
            {
                var user = await _repository.FindByLogin(loginDto.Email, loginDto.Password);
                var (Verified, NeedsUpgrade) = _passwordHasher.Check(user.Password, loginDto.Password);
                if (Verified)
                {
                    return loginDto;
                }
            }
            return null;
        }
    }
}

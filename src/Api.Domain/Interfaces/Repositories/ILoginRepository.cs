using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Interfaces.Repositories
{
    public interface ILoginRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin(string email, string password);
    }
}

using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repositories;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class UserImplementation : BaseRepository<UserEntity>, ILoginRepository, IUserRepository
    {
        private DbSet<UserEntity> _dataset;

        public UserImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<UserEntity>();
        }

        public async Task<UserEntity> FindByLogin(string email, string password)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }


        public async Task<UserEntity> Update(UserEntity user)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(user.Id));
                if (result == null)
                    return null;

                user.UpdateAt = DateTime.UtcNow;
                user.CreateAt = result.CreateAt;
                user.Password = result.Password;

                _context.Entry(result).CurrentValues.SetValues(user);
                await _context.SaveChangesAsync();

                user.Password = null;
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

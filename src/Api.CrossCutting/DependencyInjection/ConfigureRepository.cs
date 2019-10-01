using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Repositories;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();
            serviceCollection.AddScoped<ILoginRepository, UserImplementation>();

            serviceCollection.AddDbContext<MyContext>(
                options => options.UseNpgsql(ContextFactory.ConnectionString())
            );
        }
    }
}

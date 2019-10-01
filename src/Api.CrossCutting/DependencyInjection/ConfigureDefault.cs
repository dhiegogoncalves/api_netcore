
using Api.Domain.Helpers;
using Api.Domain.Interfaces;
using Api.Domain.Security;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureDefault
    {
        public static void ConfigureDependencies(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IPasswordHasher, PasswordHasher>();
        }
    }
}


using Api.Domain.Helpers;
using Api.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureHelper
    {
        public static void ConfigureDependenciesHelper(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IPasswordHasher, PasswordHasher>();
        }
    }
}

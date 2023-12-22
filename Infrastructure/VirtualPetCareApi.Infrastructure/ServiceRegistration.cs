using VirtualPetCareApi.Application.Abstractions.Services;
using VirtualPetCareApi.Application.Abstractions.Token;
using VirtualPetCareApi.Infrastructure.Services;
using VirtualPetCareApi.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;

namespace VirtualPetCareApi.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
            serviceCollection.AddScoped<IMailService, MailService>();
        }
    }
}
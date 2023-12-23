using VirtualPetCareApi.Application.Abstractions.Services;
using VirtualPetCareApi.Application.Abstractions.Services.Authentications;
using VirtualPetCareApi.Domain.Entities.Identity;
using VirtualPetCareApi.Persistence.Contexts;
using VirtualPetCareApi.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VirtualPetCareApi.Application.Repositories;
using VirtualPetCareApi.Persistence.Repositories;

namespace VirtualPetCareApi.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<VirtualPetCareApiDbContext>(option => option.UseNpgsql(Configuration.ConnectionString));
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 3;
            }).AddEntityFrameworkStores<VirtualPetCareApiDbContext>();

            services.AddScoped<IPetReadRepository, PetReadRepository>();
            services.AddScoped<IPetWriteRepository, PetWriteRepository>();

            services.AddScoped<IActivityReadRepository, ActivityReadRepository>();
            services.AddScoped<IActivityWriteRepository, ActivityWriteRepository>();

            services.AddScoped<IHealthReadRepository, HealthReadRepository>();
            services.AddScoped<IHealthWriteRepository, HealthWriteRepository>();

            services.AddScoped<IFoodReadRepository, FoodReadRepository>();
            services.AddScoped<IFoodWriteRepository, FoodWriteRepository>();

            services.AddScoped<IEducationReadRepository, EducationReadRepository>();
            services.AddScoped<IEducationWriteRepository, EducationWriteRepository>();

            services.AddScoped<ISocialInteractionReadRepository, SocialInteractionReadRepository>();
            services.AddScoped<ISocialInteractionWriteRepository, SocialInteractionWriteRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IExternalAuthentication, AuthService>();
            services.AddScoped<IInternalAuthentication, AuthService>();
        }
    }
}

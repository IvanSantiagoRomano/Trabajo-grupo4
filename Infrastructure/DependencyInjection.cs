using Application.Interfaces;
using Domain;
using Domain.Entities.Concrete.Privileges;
using Domain.Entities.Concrete.Users;
using Domain.Entities.Concrete.Vehicles;
using Infrastructure.Persistance;
using Infrastructure.Persistance.MsSqlServer.Privileges;
using Infrastructure.Persistance.MsSqlServer.Users;
using Infrastructure.Persistance.MsSqlServer.Vehicles;
using Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // EF Core
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Repositorios - (Interfaces en Domain > Implementación en Infrastructure/Persistance/MsSqlServer)
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IPrivilegeRepository, PrivilegeRepository>();

            // Unit of Work - (Interfaz en Domain > Implementación en Infrastructure/Persistance)
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Seguridad - (Interfaz en Application > Implementación en Infrastructure/Security)
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            return services;
        }
    }
}

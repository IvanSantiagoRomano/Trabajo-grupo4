using Application.Users.UseCases.Commands;
using Application.Users.UseCases.Queries;
using Application.Users.UseCases.Process;

using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            UsersUC(services);
            VehiclesUC(services);
            PrivilegesUC(services);


            return services;
        }


        private static void UsersUC(IServiceCollection srvs)
        {
            //Commands
            srvs.AddTransient<IUCCreateUser, UCCreateUser>();
            srvs.AddTransient<IUCSoftDeleteUser, UCSoftDeleteUser>();
            srvs.AddTransient<IUCUpdateUser, UCUpdateUser>();
            
            //Queries
            srvs.AddTransient<IUCGetUserById, UCGetUserById>();
            srvs.AddTransient<IUCGetAllDeletedUsers, UCGetAllDeletedUsers>();
            srvs.AddTransient<IUCGetAllUsers, UCGetAllUsers>();

            //Process
            srvs.AddTransient<IUCLoginUser, UCLoginUser>();
        }

        private static void VehiclesUC(IServiceCollection srvs)
        {
        }

        private static void PrivilegesUC(IServiceCollection srvs)
        {
        }







    }
}

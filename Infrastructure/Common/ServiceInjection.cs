using Infrastructure.IServices.IAuthService;
using Infrastructure.IServices.IHelperService;
using Infrastructure.IServices.IProjects;
using Infrastructure.Security;
using Infrastructure.Services.AuthServices;
using Infrastructure.Services.Helper;
using Infrastructure.Services.Projects;

using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Common
{
    public static  class ServiceInjection
    {
        public static IServiceCollection AddInfrustructure(this IServiceCollection services)
        {

            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IDateFormat, DateFormat>();
            services.AddSingleton<IUserAccessor, UserAccessor>();

            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITaskService, TaskService>();


            return services;
        }
    }
}

using ForumTask.Data;
using ForumTask.Services;
using ForumTask.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumTask.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IUserClientService, UserClientService>();
            services.AddSingleton<IPostClientService, PostClientService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IUserService, UserService>();
            services.AddDbContext<DataContext>(options =>
            { 
                options.UseSqlServer(config.GetConnectionString("ForumDB"));
            });
            return services;
        }
    }
}

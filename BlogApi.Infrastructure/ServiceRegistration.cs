using BlogApi.Application.Implementations;
using BlogApi.Application.Interfaces;
using BlogApi.Application.Repositories;
using BlogApi.Infrastructure.Data;
using BlogApi.Infrastructure.Repositories;
using BlogApi.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
             options.UseOracle(configuration.GetConnectionString("OracleConnection")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

        }

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPostService, PostService>();


        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entities;
using Twitter.DataAccess.Abstractions.Repositories;
using Twitter.DataAccess.Concreate;
using Twitter.DataAccess.DbContexts;

namespace Twitter.DataAccess
{
    public static class DependencyInjectionExtensions
    {

        public static IServiceCollection AddDataAccess(this IServiceCollection services,IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(config.GetConnectionString("MSSQL"), opt =>
opt.EnableRetryOnFailure()))
                .AddIdentityCore<User>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
            });


            return services;

        }

    }
}

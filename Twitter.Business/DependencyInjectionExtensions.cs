using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.Abstractions;
using Twitter.Business.Concreate;
using Twitter.Core.Entities;
using Twitter.DataAccess.DbContexts;

namespace Twitter.Business
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {

            services.AddAutoMapper(options=>options.AddMaps(typeof(DependencyInjectionExtensions).Assembly));

            services.AddScoped<IUserService, UserService>();
            

            return services;

        }
    }
}

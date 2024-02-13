using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using Models.Context;
using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Extensions {
    public static class ServiceExtension {

        public static IServiceCollection AddRepositoryServices(this IServiceCollection services, string connectionString) {
            services.AddDbContext<RestaurantContext>(conf => {
                conf.UseSqlServer(connectionString);
            });
            services.AddScoped<UserRepository>();
            services.AddScoped<OrderRepository>();
            services.AddScoped<DishRepository>();
            return services;

        }
    }
}
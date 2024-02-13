using Applications.Abstractions;
using Applications.Services;
using Applications.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Applications.Extensions {
    public static class ServiceExtension {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(typeof(UserDtoValidator).Assembly);
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrderService, OrderService>();
            return services;
        }



    }
}

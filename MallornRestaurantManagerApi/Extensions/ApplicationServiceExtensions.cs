using MallornRestaurantManagerApi.Interfaces;
using MallornRestaurantManagerApi.Models;
using MallornRestaurantManagerApi.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MallornRestaurantManagerApi.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<MallornRestaurantDatabaseSettings>(config.GetSection("MallornDatabase"));
            services.AddSingleton<RestaurantsService>();
            services.AddSingleton<UsersService>();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
using System;
using DrakeLambert.RefitTutorial.Gateway.ApiServices.ClientsApi;
using DrakeLambert.RefitTutorial.Gateway.ApiServices.JokeApi;
using DrakeLambert.RefitTutorial.Gateway.ApiServices.WeatherApi;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace DrakeLambert.RefitTutorial.Gateway.ApiServices
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            // Clients Api
            services.AddRefitClient<IClientsApi>()
                .ConfigureHttpClient(options => options.BaseAddress = new Uri("https://localhost:44391"));

            // Joke Api
            services.AddHttpClient<IJokeApi, JokeApi.JokeApi>()
                .ConfigureHttpClient(options => options.BaseAddress = new Uri("https://sv443.net"));

            // Weather Api
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            services.Configure<WeatherApiOptions>(configuration.GetSection("ApiServices:WeatherApi"));

            return services;
        }
    }
}
using System;
using DrakeLambert.RefitTutorial.Gateway.ApiServices;
using DrakeLambert.RefitTutorial.Gateway.ApiServices.ClientsApi;
using DrakeLambert.RefitTutorial.Gateway.ApiServices.JokeApi;
using DrakeLambert.RefitTutorial.Gateway.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Refit;

namespace DrakeLambert.RefitTutorial.Gateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = typeof(Startup).Namespace, Version = "v1" });
            });

            services.AddApiServices();
            services.AddMemoryCache();
            services.AddTransient<IClientJokeService, DailyClientJokeService>();
            services.AddTransient<IDailyClientInfoService, DailyClientInfoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "api"));

            app.UseSwagger();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

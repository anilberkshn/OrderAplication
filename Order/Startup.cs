using System;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using OrderCase.Config;
using OrderCase.Database.Context;
using OrderCase.Database.Interface;
using OrderCase.Middlewares;
using OrderCase.Repository;
using OrderCase.Services;

namespace OrderCase
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete("Obsolete")]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(fv=> fv.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Order", Version = "v1" });
            });
            
            var dbSettings = Configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();
            var client = new MongoClient(dbSettings.ConnectionString);
            var context = new Context(client,dbSettings.DatabaseName);
            
            services.AddSingleton<IService, OrderCase.Services.Service>();
            services.AddSingleton<IContext, Context>(_ => context);
            services.AddSingleton<IRepository, Repository.Repository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {                
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order v1"));
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
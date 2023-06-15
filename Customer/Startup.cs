using System;
using Core.Database.Context;
using Core.Database.Interface;
using Core.Middleware;
using Core.Model.Config;
using Customer.Repository;
using Customer.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;

namespace Customer
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
            services.AddControllers().AddFluentValidation(fv=> 
                fv.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CustomerModel", Version = "v1" });
            });
           
            var dbSettings = Configuration.GetSection("DatabaseSettings").Get<GenericDatabaseSettings>();
            var client = new MongoClient(dbSettings.ConnectionString);
            var context = new Context(client,dbSettings.DatabaseName);
            
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<IContext, Context>(_ => context);
            services.AddSingleton<ICustomerRepository,CustomerRepository>();
        }
        
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CustomerModel v1"));
            }
           
            app.UseMiddleware<ErrorHandlingMiddleware>();
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
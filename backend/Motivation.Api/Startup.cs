using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotenv.net;
using dotenv.net.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Motivation.Data;
using Motivation.Services;
using Motivation.Services.Readers;

namespace Motivation.Api
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
            services.AddCors();
            services.AddControllers();

            // set up dotenv to grab the environment vars
            DotEnv.Config(true, "../../.env");
            var envReader = new EnvReader();
            var connectionString = envReader.GetStringValue("DEV_CONNECTION_STRING");

            // use MSSQL
            services.AddDbContext<MotivationDbContext>(options =>
                {
                    options.EnableDetailedErrors();
                    options.UseSqlServer(connectionString);
                }
            );

            // register dependencies in the IOC container
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<IMessageReader, MessageReader>();

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // only allow a client running on localhost:8080 to consume this service
            app.UseCors(builder => builder
                .WithOrigins("https://localhost:8080")
                .AllowAnyMethod()
                .AllowAnyHeader()
           );
        }
    }
}

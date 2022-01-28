using CarShop.BL.Interfaces;
using CarShop.BL.Services;
using CarShop.DL.Interfaces;
using CarShop.DL.Repositories;
using CarShop.Extensions;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;

namespace CarShop
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
            //services.AddRazorPages();

            services.AddSingleton(Log.Logger);
            services.AddAutoMapper(typeof(Startup));

            services.AddSingleton<ICarRepository, CarInMemoryRepository>();
            services.AddSingleton<IClientRepository, ClientInMemoryRepository>();
            services.AddSingleton<IEmployeeRepository, EmployeeInMemoryRepository>();
            services.AddSingleton<IPartRepository, PartInMemoryRepository>();
            services.AddSingleton<IServiceRepository, ServiceInMemoryRepository>();

            services.AddSingleton<ICarService, CarService>();
            services.AddSingleton<IClientService, ClientService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.AddSingleton<IPartService, PartService>();
            services.AddSingleton<IServiceService, ServiceService>();

            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarShop", Version = "v1" });
            });

            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarShop v1"));
            }



            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            app.ConfigureExceptionHandler(logger);
            app.UseHttpsRedirection();
            //app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}

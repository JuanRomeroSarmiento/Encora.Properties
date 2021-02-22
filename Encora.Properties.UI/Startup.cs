using AutoMapper;
using Encora.Properties.Contracts.Infraestructure;
using Encora.Properties.DataBase;
using Encora.Properties.ResourceAccessor.Interfaces;
using Encora.Properties.ResourceAccessor.Repositories;
using Encora.Properties.Services;
using Encora.Properties.Services.Interfaces;
using Encora.Properties.Services.Services.LocalServices;
using Encora.Properties.Services.Services.RestWebApiService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;

namespace Encora.Properties.UI
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
            services.AddDbContext<PropertyDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString(Constants.DataBaseStringConnection));
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<IPropertyManager, Manager>();
            services.AddTransient<ILocalPropertyService, LocalPropertyService>();
            services.AddTransient<IRestWebApiService, RestWebApiService>();
            services.AddTransient<IPropertyRepository, PropertyRepository>();

            services.AddHttpClient(Constants.PropertyClientName, c =>
            {
                c.BaseAddress = new Uri(Configuration.GetValue<string>(Constants.PropertyURL));
            });
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(errorApp =>
                {
                    errorApp.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "text/html";

                        await context.Response.WriteAsync("<html lang=\"en\"><body>\r\n");
                        await context.Response.WriteAsync("ERROR!<br><br>\r\n");

                        var exceptionHandlerPathFeature =
                            context.Features.Get<IExceptionHandlerPathFeature>();

                        if (exceptionHandlerPathFeature?.Error is Exception)
                        {                            
                            await context.Response.WriteAsync(
                                                      "There was an error. Please, try again ...<br><br>\r\n");
                        }

                        await context.Response.WriteAsync(
                                                      "<a href=\"/\">Property</a><br>\r\n");
                        await context.Response.WriteAsync("</body></html>\r\n");
                        await context.Response.WriteAsync(new string(' ', 512));
                    });
                });
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //It allows us to know what requests the app is handling
            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Property}/{action=Index}/{id?}");
            });
        }
    }
}

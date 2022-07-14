using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using InternetStore.Models;

namespace InternetStore;
public class Startup
{
    private Appsettings _appsettings;
    public Startup(IConfiguration configuration)
    {
        _appsettings = configuration.Get<Appsettings>();

    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews()
                .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<Startup>());

        services.AddSingleton(provider => new MongoClient(_appsettings.Database.ConnectionString)
        .GetDatabase(_appsettings.Database.DatabaseName));

        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/"
                );
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=UserAccount}/{action=SignUp}"
                );
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=UserAccount}/{action=SignIn}"
                );
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Category}/{id?}"
                );
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Product}/{id?}"
                );
        });
    }
}


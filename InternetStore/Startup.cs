using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using MongoDB.Driver;
using FluentValidation.AspNetCore;

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

        services.AddAuthentication("CookieAuth").AddCookie("CookieAuth", options =>
        {
            options.Cookie.Name = "CookieAuth";
            options.LoginPath = "/UserAccount/SignIn";
            options.AccessDeniedPath = "/Home/Index"; 
        });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("User",
                policy => policy.RequireClaim("User"));

            options.AddPolicy("Admin",
                policy => policy.RequireClaim("Admin"));
        });
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

        app.UseAuthentication();

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
                pattern: "{controller=Home}/{action=Product}/{id}"
                );
        });
    }
}


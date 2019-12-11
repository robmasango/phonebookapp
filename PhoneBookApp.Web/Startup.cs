using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using PhoneBookApp.Logic.Repositories.PhoneBook;
using PhoneBookApp.Logic.Abstract;
using PhoneBookApp.Model;
using PhoneBookApp.Logic.Repositories;
using Microsoft.OpenApi.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace PhoneBookApp.Web
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
      services.AddDbContext<PhoneBookAppContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("PhoneBookDb")));

      services.AddDbContext<PhoneBookAppContext>(options =>
    options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"], b => b.MigrationsAssembly("PhoneBookApp.Web")));


      services.AddControllersWithViews();
      // In production, the Angular files will be served from this directory
      services.AddSpaStaticFiles(configuration =>
      {
        configuration.RootPath = "ClientApp/dist";
      });


      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
          Version = "v1",
          Title = "Phone Book App API",
          Description = "A simple example ASP.NET Core Web API",
          TermsOfService = new Uri("https://example.com/terms"),
          Contact = new OpenApiContact
          {
            Name = "Robert Masango",
            Email = "robmasango@gmail.com",
          },
          License = new OpenApiLicense
          {
            Name = "Use under MIT",
            Url = new Uri("https://example.com/license"),
          }
        });
        c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
      });


      // Repositories
      //System
      services.AddScoped<ILoggingRepository, LoggingRepository>();
      //Phonebook tables
      services.AddScoped<IPhoneBookRepository, PhoneBookRepository>();
      services.AddScoped<IPhoneNumberRepository, PhoneNumberRepository>();
      services.AddTransient<PhoneBookAppDbInitializer>();

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
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      if (!env.IsDevelopment())
      {
        app.UseSpaStaticFiles();
      }

      app.UseRouting();
      app.UseCors(builder => builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());

      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Phone Book Docs");
        //c.SwaggerEndpoint("/swagger/v1/swagger.json", "EFR API V1");
      });


      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller}/{action=Index}/{id?}");
      });

      app.UseSpa(spa =>
      {
        // To learn more about options for serving an Angular SPA from ASP.NET Core,
        // see https://go.microsoft.com/fwlink/?linkid=864501

        spa.Options.SourcePath = "ClientApp";

        if (env.IsDevelopment())
        {
          spa.UseAngularCliServer(npmScript: "start");
        }
      });

      //using (var serviceScope = app.ApplicationServices.CreateScope())
      //{
      //  PhoneBookAppDbInitializer.Initialize(app.ApplicationServices);

      //  // Seed the database.
      //}

    }
  }
}

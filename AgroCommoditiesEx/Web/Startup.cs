using Domain.Interface.Managers;
using Domain.Interface.Repositories;
using Domain.Interface.Services;
using Domain.Manager;
using Domain.Utilities;
using Infrastructure;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Web.Data;
//using Web.Data;

namespace Web
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
            services.AddDbContext<AgroEntities>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("DataEntities"));
                });

            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value);

            
            services.AddCors(
               options => options.AddPolicy(Constants.Cors.EnableAll, builder => builder.AllowAnyOrigin())
           );

            services.AddIdentity<User, Role>()

                .AddEntityFrameworkStores<AgroEntities>()
                .AddDefaultTokenProviders()
                .AddRoleManager<RoleManager<Role>>()
                .AddSignInManager<SignInManager<User>>()
                .AddUserManager<UserManager<User>>();

            //Data
            services.AddScoped<INotificationUtility, NotificationUtility>();

            services.AddScoped<DbContext, AgroEntities>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IBankManager, BankManager>();
            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IProductManager, ProductManager>();

            services.AddScoped<IPaymentService, CyberPayService>();

            //MailService
            services.AddScoped((o) => new ElasticEmailOptions
            {
                Url = Configuration.GetValue<string>("ElasticEmail:Url"),
                ApiKey = Configuration.GetValue<string>("ElasticEmail:ApiKey"),
                From = Configuration.GetValue<string>("ElasticEmail:From"),
                FromName = Configuration.GetValue<string>("ElasticEmail:FromName")
            });

            services.AddCors();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options => {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(key),
                     ValidateIssuer = false,
                     ValidateAudience = false
                 };
             });

            services.AddMvc().AddJsonOptions(opt => {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddSession();


            services.AddMemoryCache();  // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCors(builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
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
        }
    }
}

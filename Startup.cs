using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Authentication;
using Clinic.DataAccess;
using Clinic.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Clinic
{
    public class Startup
    {
      private IConfigurationRoot _config;
        public Startup(IConfiguration configuration, IWebHostEnvironment env/*add this here*/)
        {
            Configuration = configuration;
            var ConfigBuilder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                        .AddJsonFile("appsettings.json");
            _config = ConfigBuilder.Build();

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.RegisterServices();

            // string _key =
            // services.AddMicrosoftIdentityWebApiAuthentication(Configuration);
            services.AddSingleton(_config);
            services.AddDbContext<ClinicDbContext>();
      // options => options.UseNpgsql(Configuration.GetConnectionString("ClinicConnection"))
            services.AddControllers();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            // For Entity Framework
            // services.AddScoped<IDataAccessProvider, DataAccessProvider>();

            // For Identity
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ClinicDbContext>()
                .AddDefaultTokenProviders();

            // Adding Authentication
            services.AddAuthentication(options =>
            {
              options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
              options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
              options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>                  // Adding Jwt Bearer
            {
              options.SaveToken = true;
              options.RequireHttpsMetadata = false;
              options.TokenValidationParameters = new TokenValidationParameters()
              {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = Configuration["JWT:ValidAudience"],
                ValidIssuer = Configuration["JWT:ValidIssuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
              };
            });
    }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
                // app.UseSwaggerUI(c =>
                //                 {  c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                //                 });

            app.UseHttpsRedirection();

            app.UseRouting();

            // app.UseDefaultFiles();
            // app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapControllers();
                endpoints.MapControllers();
                // endpoints.MapControllerRoute(
                //   name: "default",
                //   pattern: "{controller=Home}/{action=HomePage}/{id?}");
            });
        }
    }
}

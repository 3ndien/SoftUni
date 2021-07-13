namespace PizzaLab.WebAPI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
    using Microsoft.OpenApi.Models;
    using PizzaLab.WebAPI.Infrastructure.Helpers;
    using PizzaLabWebAPI.Data;
    using PizzaLabWebAPI.Data.Common.Repositories;
    using PizzaLabWebAPI.Data.Models;
    using PizzaLabWebAPI.Data.Repositories;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PizzaLab.WebAPI", Version = "v1" });
            });

            services.AddDbContext<PizzaLabDbContext>(options =>
            {
                options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddAutoMapper(typeof(Startup));

            var jwtSettingsSection = this.Configuration.GetSection("JwtSettings");
            services.Configure<JWTSettings>(jwtSettingsSection);

            var jwtSettings = jwtSettingsSection.Get<JWTSettings>();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequiredLength = 8;
            })
                .AddEntityFrameworkStores<PizzaLabDbContext>()
                .AddDefaultTokenProviders();

            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaLab.WebAPI v1"));
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMvc();
        }
    }
}

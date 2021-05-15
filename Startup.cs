using System.Security.Claims;
using Ezana.ShiftManagment.API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ScheduleAPI.Extensions;

namespace Ezana.ShiftManagment.API
{
    public class Startup
    {
        private string _connectionString;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            _connectionString = Configuration.GetConnectionString("ConncetionString");

            services.ConfigureCors();
            services.ConfigureIISIntegration();
           
                 services.AddDbContext<ShiftPowerDbContext>(
                     opt => opt.UseNpgsql(_connectionString)
                  );
        /*
                 services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                 {
                     options.Password.RequireDigit = false;
                     options.Password.RequiredLength = 4;
                     options.Password.RequireNonAlphanumeric = false;
                     options.Password.RequireUppercase = false;
                     options.Password.RequireLowercase = false;
                 })
                     .AddEntityFrameworkStores<RepositoryContext>()
                      .AddDefaultTokenProviders();



                 services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
                 services.AddScoped<IUserRepository, UserRepository>();
                 services.AddScoped<IEstimationProjectRepository, EstimationProjectRepository>();

                 var appSetting = Configuration.GetSection("AppSetting");
                 services.Configure<AppSetting>(appSetting);

                 var appSettings = appSetting.Get<AppSetting>();
                 var key = Encoding.ASCII.GetBytes(appSettings.Secret);

                 JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

                 services.AddAuthentication(x =>
                 {
                     x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                     x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                 })

                  .AddJwtBearer(x =>
                 {
                     x.RequireHttpsMetadata = false;
                     x.SaveToken = true;
                     x.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = new SymmetricSecurityKey(key),
                         ValidateIssuer = false,
                         ValidateAudience = false

                     };

                 });

                 services.AddControllers();


                 services.AddTransient<DataSeed>();

                 */
            /*
                services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
                services.AddScoped<IEstimationProjectRepository, EstimationProjectRepository>();
                services.AddScoped<IProjectRepository, ProjectRepository>();

                services.AddEntityFrameworkNpgsql().

                     AddDbContext<RepositoryContext>(
                     opt => opt.UseNpgsql(_connectionString)
                  );
           

            services.AddEntityFrameworkNpgsql().

                AddDbContext<ShiftPowerDbContext>(
                opt => opt.UseNpgsql(configuration.GetConnectionString("ConncetionString"))
             );
        */
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.Authority = "http://localhost:5000";
                o.Audience = "resourceapi";
                o.RequireHttpsMetadata = false;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiReader", policy => policy.RequireClaim("scope", "api.read"));
                options.AddPolicy("Consumer", policy => policy.RequireClaim(ClaimTypes.Role, "consumer"));
            });

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            })
                .SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddControllers();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // app.UseCors("shiftPolicy");
            app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;

            });

            app.UseRouting();


            app.UseAuthentication();


            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

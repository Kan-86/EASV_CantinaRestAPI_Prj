using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CantinaApp.Core.ApplicationServices;
using CantinaApp.Core.ApplicationServices.Services;
using CantinaApp.Core.DomainServices;
using CantinaApp.Core.Entity.Models;
using CantinaApp.InfaStructure.Data;
using CantinaApp.InfaStructure.Data.SQLRepositories;
using EASV_CantinaRestAPI.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EASV_Cantina
{
    public class Startup
    {

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // Create a byte array with random values. This byte array is used
            // to generate a key for signing JWT tokens.
            Byte[] secretBytes = new byte[40];
            Random rand = new Random();
            rand.NextBytes(secretBytes);

            // Add JWT based authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    //ValidAudience = "TodoApiClient",
                    ValidateIssuer = false,
                    //ValidIssuer = "TodoApi",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
                    ValidateLifetime = true, //validate the expiration and not before values in the token
                    ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                };
            });

            services.AddCors();

            if (Environment.IsDevelopment())
            {
                // In-memory database:
                services.AddDbContext<CantinaAppContext>(opt => opt.UseInMemoryDatabase("TodoList"));
            }
            else
            {
                // Azure SQL database:dsadasd
                services.AddDbContext<CantinaAppContext>(opt =>
                         opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            }

            // Register database initializer
            //services.AddTransient<IDBInitializer, DBInitializer>();

            // Register the AuthenticationHelper in the helpers folder for dependency
            // injection. It must be registered as a singleton service. The AuthenticationHelper
            // is instantiated with a parameter. The parameter is the previously created
            // "secretBytes" array, which is used to generate a key for signing JWT tokens,
            services.AddSingleton<IAuthenticationHelper>(new AuthenticationHelper(secretBytes));

            services.AddScoped<IMainFoodRepositories, SQLMainFoodRepositories>();
            services.AddScoped<IMainFoodServices, MainFoodServices>();

            services.AddScoped<IIngredientsRepositories, SQLIngredientsRepositories>();
            services.AddScoped<IIngredientsServices, IngredientsServices>();

            services.AddScoped<IAllergensRepositories, SQLAllergenRepositories>();
            services.AddScoped<IAllergenServices, AllergenServices>();

            services.AddScoped<ISpecialOffersRepositories, SQLSpecialOffersRepositories>();
            services.AddScoped<ISpecialOffersServices, SpecialOffersServices>();

            services.AddScoped<IMOTDRepositories, SQLMOTDRepositories>();
            services.AddScoped<IMOTDServices, MOTDServices>();

            services.AddScoped<IUserRepositories, SQLUserRepositories>();
            services.AddScoped<IUsersServices, UsersServices>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.MaxDepth = 2;

            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader()
                        .AllowAnyMethod());
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("https://petshop-684d3.firebaseapp.com").AllowAnyHeader()
                        .AllowAnyMethod());
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("https://localhost:44362").AllowAnyHeader()
                      .AllowAnyMethod());
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {


            // For convenience, I want detailed exception information always. However, this statement should
            // be removed, when the application is released.
            app.UseDeveloperExceptionPage();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {

                    var ctx = scope.ServiceProvider.GetService<CantinaAppContext>();
                    ctx.Database.EnsureCreated();
                    DBInitializer.SeedDb(ctx);
                }


            }
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {

                    var services = scope.ServiceProvider;
                    var dbContext = services.GetService<CantinaAppContext>();
                    dbContext.Database.EnsureCreated();
                //    var dbInitializer = services.GetService<IDBInitializer>();
                //    dbContext.Database.EnsureCreated();
                //    dbInitializer.SeedDb(dbContext);

                }
                app.UseHsts();
            }

            // Use authentications
            app.UseAuthentication();

            // Enable CORS (must precede app.UseMvc()):
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseMvc();
        }
    }
}

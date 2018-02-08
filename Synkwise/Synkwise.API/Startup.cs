using Identity.Dapper;
using Identity.Dapper.Models;
using Identity.Dapper.SqlServer.Connections;
using Identity.Dapper.SqlServer.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Synkwise.API.App_Start;
using Synkwise.API.Middleware;
using Synkwise.API.Security;
using Synkwise.Repository.Models.Account;
using System;
using System.Text;

namespace Synkwise.API
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
            services.ConfigureDapperConnectionProvider<SqlServerConnectionProvider>(Configuration.GetSection("DapperIdentity"))
                    .ConfigureDapperIdentityCryptography(Configuration.GetSection("DapperIdentityCryptography"))
                    .ConfigureDapperIdentityOptions(new DapperIdentityOptions { UseTransactionalBehavior = false }); //Change to True to use Transactions in all operations

            services.AddIdentity<UserEntity, RoleEntity>(setup =>
                    {
                        setup.Password.RequireDigit = false;
                        setup.Password.RequiredLength = 1;
                        setup.Password.RequireLowercase = false;
                        setup.Password.RequireNonAlphanumeric = false;
                        setup.Password.RequireUppercase = false;
                    })
                .AddDapperIdentityFor<SqlServerConfiguration>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer(options =>
                 {
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateLifetime = true,
                         ValidateIssuer = false, // this is true by default
                         ValidateAudience = false, // this is true by default
                         ValidateIssuerSigningKey = true,
                         ClockSkew = TimeSpan.Zero,
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Token.SECRET))
                     };
                 });

            services.AddAuthorization(o =>
            {
                o.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .RequireRole("Provider", "Admin", "Resident Manager")
                    .Build();
            });

            DependencyResolver.Initialize(services);
            Mappings.Initialize();

            services.AddMvc();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders",
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseAuthentication();

            app.UseMvc();

            app.UseCors("AllowAllHeaders");
        }
    }
}

using APIController.Annotations;
using APIController.Business.Interfaces;
using APIController.Business.Interfaces.Repository.Logs;
using APIController.Business.Interfaces.Repository.Users;
using APIController.Business.Interfaces.Service.Logs;
using APIController.Business.Interfaces.Service.Users;
using APIController.Business.Services.Logs;
using APIController.Business.Services.Users;
using APIController.Data.DataContext;
using APIController.Data.Repository.Logs;
using APIController.Data.Repository.Users;
using APISummarizationClient.Client;
using APISummarizationClient.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace APIController
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
            services.AddControllers();

            #region :: Injeção de Dependência
            services.AddSingleton<APIControllerDataContext, APIControllerDataContext>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IApiTokenLogRepository, ApiTokenLogRepository>();
            services.AddTransient<IApiAccessLogRepository, ApiAccessLogRepository>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IApiAccessLogService, ApiAccessLogService>();
            services.AddTransient<IApiTokenLogService, ApiTokenLogService>();

            services.AddTransient<IApiClient, ApiClient>();
            services.AddTransient<ISummarizationClient, SummarizationClient>();
            #endregion

            services.AddCors(c => c.AddPolicy("EnableAllCrossOriginRequests", builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "apicontroller",
                        ValidAudience = "apicontroller",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecretKey"])),
                        ClockSkew = TimeSpan.Zero
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            Debug.WriteLine("Token inválido: " + context.Exception.Message);
                            return Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {
                            Debug.WriteLine("Token válido: " + context.SecurityToken);
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "APIController.xml"));
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "APIController", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"Autorização via JWT usando o esquema Bearer.
                      Digite 'Bearer' [espaço] e seu JWT gerado pelo método Auth.Authentication.
                      nExemplo: 'Bearer 123abc123abc'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                                {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseRouting();

            app.UseCors("EnableAllCrossOriginRequests");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIController");
            });
        }
    }
}

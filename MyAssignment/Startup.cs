using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyAssignment.Data;
using MyAssignment.IdentityServer;
using System;
using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using AutoMapper;
using MyAssignment.Models;
using Microsoft.AspNetCore.Identity;
using MyAssignment.Respositories.ProductRespo;
using System.Reflection;
using MyAssignment.Respositories.CategoryRespo;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Http;
using MyAssignment.Respositories.RatingRespo;
using MyAssignment.Services;
using MyAssignment.Respositories.UserRepo;

namespace MyAssignment
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public static Dictionary<string, string> clientUrls;

        public void ConfigureServices(IServiceCollection services)
        {
            clientUrls = new Dictionary<string, string>
            {
                ["CustomerSite"] = Configuration["ClientUrl:CustomerSite"],
                ["BackendSite"] = Configuration["ClientUrl:BackendSite"],
            };

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddTransient<IStorageService, FileStorageService>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IRatingRespo, RatingRespository>();
            services.AddTransient<IProduct, ProductRespository>();
            services.AddTransient<ICateRespo, CategoryRespository>();
            services.AddTransient<IUserRespo, UserRespo>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.EmitStaticAudienceClaim = true;
            })
              .AddInMemoryIdentityResources(IdentityServerConfig.IdentityResources)
              .AddInMemoryApiScopes(IdentityServerConfig.ApiScopes)
              .AddInMemoryClients(IdentityServerConfig.Clients(clientUrls))
              .AddAspNetIdentity<User>()
              .AddProfileService<CustomProfileService>()
              .AddDeveloperSigningCredential(); // not recommended for production - you need to store your key material somewhere secure

            services.AddAuthentication()
               .AddLocalApi("Bearer", option =>
               {
                   option.ExpectedScope = "assignment.api";
               });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Bearer", policy =>
                {
                    policy.AddAuthenticationSchemes("Bearer");
                    policy.RequireAuthenticatedUser();
                });
            });

            services.AddControllersWithViews();
            //services.AddCors(options =>
            //{
            //    options.AddPolicy(name: MyAllowSpecificOrigins,
            //                      builder =>
            //                      {
            //                          builder.WithOrigins("https://sa60a6887add68499ab424b3.z23.web.core.windows.net")
            //                          .AllowAnyHeader()
            //                          .AllowAnyMethod();
            //                      });
            //});



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Assignment API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            TokenUrl = new Uri("/connect/token", UriKind.Relative),
                            AuthorizationUrl = new Uri("/connect/authorize", UriKind.Relative),
                            Scopes = new Dictionary<string, string> { { "assignment.api", "My Assignment API" } }
                        },
                    },
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new List<string>{ "assignment.api" }
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
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);


            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseCors(option =>
            {
                option.WithOrigins("https://sa60a6887add68499ab424b3.z23.web.core.windows.net").AllowAnyOrigin()
                                                       .AllowAnyHeader()
                                                       .AllowAnyMethod();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.OAuthClientId("swagger");
                c.OAuthClientSecret("secret");
                c.OAuthUsePkce();
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Assignment API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}

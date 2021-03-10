using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Internal;
using FestivalProject.BL.Facade;
using FestivalProject.BL.Helpers;
using FestivalProject.BL.Mapper;
using FestivalProject.BL.Services;
using FestivalProject.DAL;
using FestivalProject.DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NSwag.AspNetCore;

namespace FestivalProject
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

            services.AddCors(options =>
            {
                options.AddPolicy("AllOrigins",
                    builder =>
                    {
                        builder.AllowAnyHeader()
                            .AllowAnyOrigin()
                            .AllowAnyMethod();
                    });
            });
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddDbContext<FestivalDbContext>(option => option.UseSqlServer(Configuration["database:connection"]));
            //needed for azure sql server

            //services.AddDbContext<FestivalDbContext>(option => option.UseSqlServer(Configuration["database:azure-connection"]));

            services.AddControllers();

            services.AddScoped<InterpretRepository>();
            services.AddScoped<FestivalRepository>();
            services.AddScoped<MemberRepository>();
            services.AddScoped<UserRepository>();
            services.AddScoped<StageRepository>();
            services.AddScoped<ReservationRepository>();
            services.AddScoped<FestivalInterpretRepository>();
            services.AddScoped<StageInterpretRepository>();

            services.AddScoped<InterpretFacade>();
            services.AddScoped<FestivalFacade>();
            services.AddScoped<UserFacade>();
            services.AddScoped<ReservationFacade>();
            services.AddScoped<StageFacade>();
            services.AddScoped<FestivalInterpretFacade>();
            services.AddScoped<StageInterpretFacade>();


            services.AddAutoMapper(typeof(InterpretProfiles), typeof(MemberProfiles), 
                typeof(FestivalProfiles), typeof(FestivalInterpretProfiles),
                typeof(StageProfiles), typeof(StageInterpretProfiles),
                typeof(UserProfiles),typeof(ReservationProfiles));

            services.AddOpenApiDocument(document =>
            {
                document.DocumentName = "FestivalApi";
                document.Title = "FestivalApi";
            });

            // configure strongly typed settings object
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            UpdateDatabase(app);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseMiddleware<JwtMiddleware>();
            // global cors policy
            app.UseCors("AllOrigins");

            app.UseMvc();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOpenApi();

            app.UseSwaggerUi3(settings =>
            {
                settings.SwaggerRoutes.Add(new SwaggerUi3Route("FestivalApi", "/Swagger/FestivalApi/swagger.json"));
            });
            



        }

        private void UpdateDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<FestivalDbContext>();
            context.Database.Migrate();
        }
    }
}

using AutoMapper;
using ChitFundMgmtApi.ChitMgmt.Get.v1.Dto_s;
using ChitFundMgmtApi.ChitMgmt.Post.v1.Dto_s;
using ChitFundMgmtApi.ChitMgmt.Post.v1.Entities;
using ChitFundMgmtApi.Data;
using ChitFundMgmtApi.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ChitFundMgmtApi.Middlewares
{
    public static class ServiceConfiguration
    {
        #region Methods
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ChitDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("connectionString")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddCors(
                options => options.AddPolicy("AllowAngular", policy =>
                {
                    policy.AllowAnyOrigin();
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                }));

            services.AddMvc();
        }

        public static void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder => appBuilder.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
                }));
            }

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CreateChitDto, Chit>();
                cfg.CreateMap<Chit, GetChitDto>()
                .ForMember(
                    dest => dest.StatusText,
                    opt => opt.MapFrom(
                        src => (ChitMgmtApiConstants.ChitStatus)src.StatusId));
            });

            app.UseStatusCodePages();
            app.UseCors("AllowAngular");
            app.UseMvc();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
        #endregion Methods
    }
}

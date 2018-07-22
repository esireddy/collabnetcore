using AutoMapper;
using ChitCore.Common.Dtos.v1.get;
using ChitCore.Common.Dtos.v1.patch;
using ChitCore.Common.Dtos.v1.post;
using ChitCore.Common.v1.Dtos;
using ChitCore.Data.v1;
using ChitCore.Data.v1.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static ChitCore.Common.v1.ChitCoreApiConstants;

namespace ChitCoreApi.Middlewares
{
    #region Methods

    public static class ServiceConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //configure DbContext
            services.AddDbContext<ChitDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("chitConnectionString")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddCors(setupAction => setupAction.AddPolicy("Allowngchitapp", policy =>
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
                app.UseExceptionHandler(configure => configure.Run(async handler =>
                {
                    handler.Response.StatusCode = 500;
                    await handler.Response.WriteAsync("An unexpected fault happened. Please try again later.");
                }));
            }

            Mapper.Initialize(config =>
            {
                config.CreateMap<CreateChitDto, Chit>();
                config.CreateMap<Chit, GetChitDto>()
                .ForMember(dest => dest.StatusText, opt => opt.MapFrom(src => (ChitStatus)src.StatusId));

                config.CreateMap<CreateUserDto, User>();
                config.CreateMap<User, GetUserDto>();
                //config.CreateMap<ChitUser, GetChitUserDto>();
                config.CreateMap<Chit, PatchChitDto>();
                config.CreateMap<PatchChitDto, Chit>();
                //config.CreateMap<CreateChitUser, ChitUser>();
            });

            app.UseStatusCodePages();

            app.UseCors("Allowngchitapp");

            app.UseMvc();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }

    #endregion Methods
}

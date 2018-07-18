using ChitCoreApi.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace ChitCoreApi
{
    public class Startup
    {
        #region Members

        private readonly IConfiguration configuration;

        #endregion Members

        #region Constructors

        public Startup(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        #endregion Constructors


        #region Methods

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            ServiceConfiguration.ConfigureServices(services, configuration);

            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            ServiceConfiguration.Configure(app, env);
        }

        #endregion Methods
    }
}

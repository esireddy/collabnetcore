using ChitFundMgmtApi.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChitFundMgmtApi
{
    public class Startup
    {
        #region Members
        private IConfiguration configuration;
        #endregion Members

        #region Constructors
        public Startup(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        #endregion Constructors

        #region Mehods
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            ServiceConfiguration.ConfigureServices(services, configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            ServiceConfiguration.Configure(app, env);
        }
        #endregion Methods
    }
}

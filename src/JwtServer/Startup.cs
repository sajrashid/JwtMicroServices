using Extensions;
using JwtServer.MiddleWare;
using JwtServer.Services.APIKey;
using JwtServer.Services.Identity.Claims;
using JwtServer.Services.Identity.Tokens;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JwtServer
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
          
            // Most of the confguration is in the Extensions
            services.AddExtensionsConfig();
             

            // register  claims service
            services.AddSingleton<IClaimsFactory, ClaimsFactory>();



            //register  Token service
            services.AddSingleton<ITokensFactory, TokensFactory>();



            //register  API Key Generating service
            services.AddSingleton<IApiKeysService, APIKeysService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           

            // This is the error handling middleWare 
            // this traps error on invoking next
            // This Middleware neeeds to be before other custom middleware to work
            app.UseMiddleware<ErrorHandlingMiddleware>();

            // run the custom auth middleware componenet
            // at the moment it just checks if your autheticated with bearer
            app.UseMiddleware<VerifyTokenSenderMiddleWare>();

            // run the custom auth middleware componenet
            // at the moment it just checks if your autheticated with AD
            app.UseMiddleware<WindowsAuthenticationMiddleWare>();

            // Use Extensions // Most of the confguration is in the Extensions
            app.UseExtensionsConfig(env);
          


           
        }
    }
}

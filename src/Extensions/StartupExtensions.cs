using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Extensions.Swagger;
using Extensions.JWT;
using Extensions.CORS;
using Extensions.Logger;
using Microsoft.AspNetCore.Hosting;

namespace Extensions
    {
        public static class StartupExtensions
        {
            public static IServiceCollection AddExtensionsConfig(this IServiceCollection services)
            {

                //add logger
                services.AddLoggerConfig();


                // add Swagger
                services.AddSwaggerConfig();


                // Add JWT Config
                services.AddJWTConfig();


                //Add MVC
                services.AddMvc();



                return services;
            }


            public static IApplicationBuilder UseExtensionsConfig(this IApplicationBuilder app, IHostingEnvironment env)
            {

            if (env.IsLocal())
            {
                app.UseDeveloperExceptionPage();

            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsSIT())
            {
             //TODO

            }

            if (env.IsUAT())
            {
             //TODO

            }


            if (env.IsProduction())
            { 
             //TODO

            }
          

                // auth
                app.UseAuthentication();


                //use logger //pass the hosting environment
                app.UseLoggerConfig(env);


                // set startup file to index.html for easy testing
                app.UseDefaultFiles();


                //addsupport for static file
                app.UseStaticFiles();


                //enable CORS
                app.UseCorsConfig();


                // enable swagger
                app.UseSwaggerConfig();


            


                // MVC
                app.UseMvc();


                return app;
            }
        }
    }

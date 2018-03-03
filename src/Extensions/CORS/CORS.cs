using Microsoft.AspNetCore.Builder;

namespace Extensions.CORS
{
    
        public static class CorsServiceExtensions
        {
          

            public static IApplicationBuilder UseCorsConfig(this IApplicationBuilder app)
            {
                // this should be loaded from DB, that way we can keep it the same across all API's
                app.UseCors(policy =>
                {
                    policy.WithOrigins(
                        "http://localhost:5005", //we just need to add the host names and perhaps FQDN
                        "http://localhost");

                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.WithExposedHeaders("WWW-Authenticate");
                });

                return app;
            }
        }
}



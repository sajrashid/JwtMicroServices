using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Extensions.JWT
{
    public static class JWTServiceExtensions
    {
        public static IServiceCollection AddJWTConfig(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer(options =>
                 {
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuer = false,
                         ValidateAudience = false,
                         ValidateLifetime = true,
                         ValidateIssuerSigningKey = true,
                         ClockSkew = TimeSpan.Zero,

                        // JWT Key we can use app.settings
                        //TODO get key from Appsetting for dev
                        //TODO for live we must use and environment variable
                        // Don't forget update the TokenService if you change it here or we will get a key mismatch
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("fjboJU3s7rw2Oafzum5fBxZoZ5jihQRbpBZcxZFd/gY="))

                     };
                 });


            // TODO
            // What does the below do, does it offer any advantages ?
            //services.AddAuthorization(options => { options.DefaultPolicy = new 
            //AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build(); });


            return services;
        }

    }
}

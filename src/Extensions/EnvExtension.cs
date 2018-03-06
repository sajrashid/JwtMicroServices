using Microsoft.AspNetCore.Hosting;

namespace Extensions
{
    public static class EnvExtension
    {   //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments
        //ASP.NET Core reads the environment variable ASPNETCORE_ENVIRONMENT
        //at application startup and stores that value in 
        //IHostingEnvironment.EnvironmentName. ASPNETCORE_ENVIRONMENT can be
        //set to any value, but three values are supported by the framework:
        //Development, Staging, and Production. If ASPNETCORE_ENVIRONMENT
        // isn't set, it will default to Production.


        // extended to Local, SIT, Development, UAT, Staging, and Production
        // we will use Local, SIT, Development, UAT, and Production
        // from cmd run command below
        // set ASPNETCORE_ENVIRONMENT=Local on your machine
        const string Local = "Local";
        const string UAT = "UAT";
        const string SIT = "SIT";


        public static bool IsUAT(this IHostingEnvironment env)
        {
            return env.IsEnvironment(UAT);
        }

        public static bool IsSIT(this IHostingEnvironment env)
        {
            return env.IsEnvironment(SIT);
        }

        public static bool IsLocal(this IHostingEnvironment env)
        {
            return env.IsEnvironment(Local);
        }
    }
}

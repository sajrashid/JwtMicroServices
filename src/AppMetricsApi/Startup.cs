using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace AppMetricsApi
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
            // adds app metrics
            services.AddMetrics()
              .AddHealthChecks()
              .AddJsonSerialization()
              .AddMetricsMiddleware(options => options.IgnoredHttpStatusCodes = new[] { 404 });
            services.AddMvc(options => options.AddMetricsResourceFilter());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app metrics 
            //https://al-hardy.blog/2017/04/28/asp-net-core-monitoring-with-influxdb-grafana/
            app.UseMetrics();

            // set startup file to index.html for easy testing
            app.UseDefaultFiles();
            //added support for static file
            // 401's on favicons are no more!
            app.UseStaticFiles();


            app.UseMvc();
        }
    }
}

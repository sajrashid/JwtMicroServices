using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.IO;

namespace Extensions.Logger
    {
        public static class LoggerServiceExtensions
        {
            public static IServiceCollection AddLoggerConfig(this IServiceCollection services)
            {

                //serilog
                services.AddLogging(loggingBuilder =>
                 loggingBuilder.AddSerilog(dispose: true));

                var loggerServices = new ServiceCollection()
                   .AddLogging(builder =>
                   {
                       builder.AddSerilog();
                   });

                return services;
            }


            public static IApplicationBuilder UseLoggerConfig(this IApplicationBuilder app, IHostingEnvironment env)
            {
            var windir = Environment.GetEnvironmentVariable("WinDir");
            var callingAppName = env.ApplicationName;
            var logfileFolder = (windir + "\\logs\\" + callingAppName);

            if (env.IsDevelopment())
            {// logfiles save in %windir%/log
                bool IsFolderCreated = Directory.Exists(logfileFolder);
                if (!IsFolderCreated)
                {
                    Directory.CreateDirectory(logfileFolder);
                }
            }

            if (env.IsStaging())
            {// logfiles save 
               //TODO
            }

            if (env.IsProduction())
            {// logfiles save 
               //TODO

            }



            //add serilog https://github.com/serilog/serilog-extensions-logging
            // https://github.com/serilog/serilog-extensions-logging/blob/dev/samples/Sample/Program.cs
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(logfileFolder + "\\log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

                var startTime = DateTimeOffset.UtcNow;

                Log.Logger.Information("Started at {StartTime} and 0x{Hello:X} is hex of 42", startTime, 42);

                return app;
            }
        }
    }

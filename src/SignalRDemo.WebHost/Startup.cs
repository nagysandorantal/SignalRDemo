using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SignalRDemo.WebHost
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(minLevel: LogLevel.Information);
            ILogger logger = loggerFactory.CreateLogger("Startup");
            logger.LogInformation("Startup.Configure");

            app.UseIISPlatformHandler();

            app.Use(async (context, next) =>
            {
                logger.LogInformation( "Startup.Configure.Use.Response Start" );
                await context.Response.WriteAsync("Hello World!");
                logger.LogInformation( "Startup.Configure.Use.Response End" );

                logger.LogInformation( "Startup.Configure.Use.Next Start" );
                await next();
                logger.LogInformation( "Startup.Configure.Use.Next End" );
            } );

            app.Run( async ( context ) =>
            {
                logger.LogInformation( "Startup.Configure.Run.Response Start" );
                await context.Response.WriteAsync( "Hello World!" );
                logger.LogInformation( "Startup.Configure.Run.Response End" );
            } );
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}

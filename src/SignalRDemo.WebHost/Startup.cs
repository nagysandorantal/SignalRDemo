using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SignalRDemo.WebHost.Controllers;
using SignalRDemo.WebHost.Services;
using SignalRDemo.WebHost.ViewModels;

namespace SignalRDemo.WebHost
{
    public class Startup
    {
        private readonly IHostingEnvironment _hostEnv;

        public Startup( IHostingEnvironment hostEnv )
        {
            if ( hostEnv == null )
                throw new ArgumentNullException( nameof(hostEnv) );

                _hostEnv = hostEnv;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices( IServiceCollection services )
        {
            services.AddMvc();

            services.AddSingleton<IViewModelService, ViewModelService>();
            services.AddScoped<HomeController>();
            services.AddScoped<HomeViewModel>();
            services.AddScoped<ChatViewModel>();

            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, ILoggerFactory loggerFactory )
        {
            if ( _hostEnv.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddConsole( minLevel: LogLevel.Information );
            ILogger logger = loggerFactory.CreateLogger( "Startup" );
            logger.LogInformation( "Startup.Configure" );

            app.UseIISPlatformHandler();
            app.UseMvcWithDefaultRoute();
            app.UseStatusCodePages();
            app.UseStaticFiles();

            app.UseSignalR();
        }

        // Entry point for the application.
        public static void Main( string[] args ) => WebApplication.Run<Startup>( args );
    }
}

using System;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SignalRDemo.WebHost.Services;
using SignalRDemo.WebHost.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SignalRDemo.WebHost.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceProvider _serviceProvider;

        public HomeController( IServiceProvider serviceProvider, IUrlHelper urlHelper )
        {
            if ( serviceProvider == null )
                throw new ArgumentNullException( nameof( serviceProvider ) );

            _serviceProvider = serviceProvider;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = _serviceProvider.GetService<HomeViewModel>();

            return View( model );
        }

        // GET: /<controller>/
        public IActionResult Chat()
        {
            var model = _serviceProvider.GetService<ChatViewModel>();
            return View(model);
        }
    }
}

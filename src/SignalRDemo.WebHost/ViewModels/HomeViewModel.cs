using Microsoft.AspNet.Mvc;

namespace SignalRDemo.WebHost.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel( IUrlHelper urlHelper )
        {
            AboutUrl = urlHelper.Action( "About", "Home" );
        }

        public string Title { get; } = "Task Manager";
        public string AboutUrl { get; set; }
    }
}
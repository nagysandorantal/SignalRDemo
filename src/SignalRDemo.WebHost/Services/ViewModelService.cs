using System;
using System.Diagnostics;
using SignalRDemo.WebHost.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace SignalRDemo.WebHost.Services
{
    public class ViewModelService : IViewModelService
    {
        private readonly IServiceProvider _serviceProvider;

        public ViewModelService( IServiceProvider serviceProvider )
        {
            if ( serviceProvider == null )
                throw new ArgumentNullException(nameof( serviceProvider ) );

            _serviceProvider = serviceProvider;
        }

        public T GetViewModel<T>() where T : new()
        {
            return _serviceProvider.GetService<T>();
        }

        public HomeViewModel GetHomeViewModel()
        {
            Debug.Assert( _serviceProvider != null, "_serviceProvider != null" );
            return _serviceProvider.GetService<HomeViewModel>();
        }
    }
}

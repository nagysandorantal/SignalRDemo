using SignalRDemo.WebHost.ViewModels;

namespace SignalRDemo.WebHost.Services
{
    public interface IViewModelService
    {
        T GetViewModel<T>() where T : new();
        HomeViewModel GetHomeViewModel();
    }
}
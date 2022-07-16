using Jab;
using WindowsApplication.Interfaces;
using WindowsApplication.Pages;
using WindowsApplication.Views;

namespace WindowsApplication.Services
{
    [ServiceProvider]
    [Singleton(typeof(IJustaSessionService), typeof(JustaSessionService))]
    [Singleton(typeof(IDialogService), typeof(DialogService))]

    public partial class MyServiceProvider
    {
    }
}

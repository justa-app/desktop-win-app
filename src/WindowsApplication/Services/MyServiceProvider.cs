using Jab;
using WindowsApplication.Interfaces;
using WindowsApplication.Pages;
using WindowsApplication.Views;

namespace WindowsApplication.Services
{
    [ServiceProvider]
    [Singleton(typeof(IJustaSessionService), typeof(JustaSessionService))]

    public partial class MyServiceProvider
    {
    }
}

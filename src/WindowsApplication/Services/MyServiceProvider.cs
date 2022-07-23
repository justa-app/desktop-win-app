using Jab;
using WindowsApplication.Interfaces;
using WindowsApplication.Pages;
using WindowsApplication.Views;

namespace WindowsApplication.Services
{
    [ServiceProvider]
    [Singleton(typeof(IJustaSessionService), typeof(JustaSessionService))]
    [Singleton(typeof(IOpenMailService), typeof(OpenMailService))]

    public partial class MyServiceProvider
    {
    }
}

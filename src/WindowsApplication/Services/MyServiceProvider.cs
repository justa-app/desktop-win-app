using Jab;
using WindowsApplication.Interfaces;
using WindowsApplication.Views;

namespace WindowsApplication.Services
{
    [ServiceProvider]
    [Singleton(typeof(StartChatPage))]

    [Singleton(typeof(IJustaSessionService), typeof(JustaSessionService))]

    public partial class MyServiceProvider
    {
    }
}

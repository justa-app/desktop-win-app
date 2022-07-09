using Jab;
using WindowsApplication.Interfaces;

namespace WindowsApplication.Services
{
    [ServiceProvider]

    [Singleton(typeof(IJustaSessionService), typeof(JustaSessionService))]

    public partial class MyServiceProvider
    {
    }
}

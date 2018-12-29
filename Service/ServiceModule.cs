using Dal;
using DI;
using DI.Autofac;

namespace Service
{

    [DependsOn(typeof(DalModule))]
    public class ServiceModule : DiModule
    {
    }
}

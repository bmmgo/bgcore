using DI;
using DI.Autofac;

namespace Service
{
    [DependsOn(nameof(Dal))]
    public abstract class BaseService : ISingleton
    {
    }
}

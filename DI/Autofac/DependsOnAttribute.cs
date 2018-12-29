using System;

namespace DI.Autofac
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class DependsOnAttribute : Attribute
    {
        public Type Type { get; }
        public DependsOnAttribute(Type type)
        {
            Type = type;
        }
    }
}

using System;

namespace DI.Autofac
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class DependsOnAttribute : Attribute
    {
        public string AssemblyName { get; }
        public DependsOnAttribute(string assemblyName)
        {
            AssemblyName = assemblyName;
        }
    }
}

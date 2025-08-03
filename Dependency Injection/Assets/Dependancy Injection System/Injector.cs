using System;

namespace DependancyInjection
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public sealed class InjectorAttribute : Attribute
    {
        public InjectorAttribute() { }

    }
    [AttributeUsage(AttributeTargets.Method)]

    public sealed class ProvideAttribute : Attribute
    { 
        public ProvideAttribute() { }
    }


    //Marker Interface
    public interface IDependencyProvider { }


    public class Injector
    {



    }



}

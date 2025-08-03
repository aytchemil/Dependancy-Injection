using System;
using UnityEngine;

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

    

    public class ClassA : MonoBehaviour
    {

    }

    public class ClassB : MonoBehaviour
    {

    }


    public class Injector
    {



    }




}

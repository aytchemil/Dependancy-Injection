using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using DesignPatterns.CreationalPatterns;
using System.Linq;
using UnityEditor.VersionControl;

namespace DependencyInjection
{
    //Purpose:
    // - Any Method or Field marked with the [Inject] Attribute we expect that dependency to be satisfied
    //   by our system
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public sealed class InjectAttribute : Attribute
    {
        public InjectAttribute() { }

    }



    //Purpose:
    // - Any method marked with the [Provide] Attribute we expect to supply an instance of a dependancy
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class ProvideAttribute : Attribute
    { 
        public ProvideAttribute() { }
    }


    //Marker Interface
    public interface IDependencyProvider { }

    //Purpose:
    //
    // Have only 1 Injector
    public class Injector : Singleton<Injector> 
    {
        //Looking for Instaance, public, non public : Methods and Fields
        const BindingFlags k_bindingFlags = BindingFlags.Instance |
                                            BindingFlags.Public |
                                            BindingFlags.NonPublic;

        //Find all the dependancies and store them in the dictionary by type
        readonly Dictionary<Type, object> registry = new Dictionary<Type, object>();

        protected override void Awake()
        {
            base.Awake();


            //Find all modules implementing IDependancyProvider
            var providers = FindMonoBehaviors().OfType<IDependencyProvider>();

            //Register each found IDependencyProvider into our dictionary
            foreach (var provider in providers)
            {
                RegisterProvider(provider);
            }
            Debug.Log($"Registered all Providers");

        }

        //Purpose: Every IDependencyProvider passed into (RegisterProvider) most likely has a method or field
        //         annotated with a [Provide] Attribute 
        void RegisterProvider(IDependencyProvider provider)
        {
            //Debug.Log($"Attempting To Register Provider {provider.GetType().Name}");

            //Store for all the methods of the provider
            var methods = provider.GetType().GetMethods(k_bindingFlags);

            //Find the methods marked with [Provide]
            foreach (var method in methods)
            {
                //If theres no [Provide] Attribute, then continue to the next iteration immedietly
                if (!Attribute.IsDefined(method, typeof(ProvideAttribute))) continue;

                //Debug.Log($"Registering...");


                //Checking the return type of the Method, Ie: void, int, etc
                var returnType = method.ReturnType;

                //Invoking the Method, and getting whatever it returns
                var providedInstance = method.Invoke(provider, null);

                //If the returned (provided) thing we asked for is there, add it to the registry
                if (providedInstance != null)
                {
                    registry.Add(returnType, providedInstance);
                    Debug.Log($"Registered {returnType.Name} from {provider.GetType().Name}");
                }
                else //Otherwise throw an expection
                    throw new Exception($"Provider {provider.GetType().Name} returned null for {returnType.Name}");
            }
        }

        //Helper Method:
        // Purpose: Return us all of the Monobehaviors in the scene
        static MonoBehaviour[] FindMonoBehaviors()
        {
            return FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.InstanceID);
        }


    }



}

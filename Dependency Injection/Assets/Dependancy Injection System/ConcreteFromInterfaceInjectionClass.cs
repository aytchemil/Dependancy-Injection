using UnityEngine;

namespace DependencyInjection {
    public interface ISomeInjectionClass 
    {
        ISomeInjectionClass ProvideThisClass();
        public void Initialize();
    }


    public class ConcreteFromInterfaceInjectionClass : MonoBehaviour, IDependencyProvider, ISomeInjectionClass
    {
        [Provide]
        ISomeInjectionClass ISomeInjectionClass.ProvideThisClass()
        {
            return this;
        }

        void ISomeInjectionClass.Initialize()
        {
            Debug.Log("Initialized Concrete Injection Class from Interface Injection");
        }

    }



}


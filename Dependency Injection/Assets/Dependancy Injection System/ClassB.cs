using UnityEngine;

namespace DependencyInjection
{
    public class ClassB : MonoBehaviour
    {
        [Inject] ServiceA serviceA; //Field Injection
        [Inject] ServiceB serviceB; //Filed Injection
        FactoryA factoryA;

        [Inject] //Method Injection
        public void Init(FactoryA factoryA)
        {
            this.factoryA = factoryA;
        }



        private void Start()
        {
            serviceA.Initialize("ServiceA initialized from ClassB");
            serviceB.Initialize("ServiceB initialized from ClassB");
            factoryA.CreatedServiceA().Initialize("ServiceA initialized from FactoryA");
        }
    }



}

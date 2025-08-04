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

    }



}

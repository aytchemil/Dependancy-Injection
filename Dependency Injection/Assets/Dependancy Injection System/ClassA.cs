using UnityEngine;
using System;

namespace DependencyInjection
{
    public class ClassA : MonoBehaviour
    {
        //Field To Hold ServiceA
        ServiceA serviceA;



        //Accepts an Injection and Assigns it to the field
        [Inject]
        public void Init(ServiceA serviceA)
        {
            this.serviceA = serviceA;
        }

        private void Start()
        {
            serviceA.Initialize("ServiceA initialized from ClassA");
        }






    }



}

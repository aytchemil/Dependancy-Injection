using UnityEngine;

namespace DependencyInjection {

    public class SelfInjectClass : MonoBehaviour, IDependencyProvider
    {
        [Provide]
        SelfInjectClass ProvideThisClass()
        {
            return this;
        }


        public void Initialize()
        {
            Debug.Log("SelfInjectClass.Initialize()");
        }

    }

}

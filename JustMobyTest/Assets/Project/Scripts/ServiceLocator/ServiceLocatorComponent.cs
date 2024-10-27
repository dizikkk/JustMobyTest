using System;
using UnityEngine;

namespace JustMobyTest.ServiceLocator
{
    public class ServiceLocatorComponent : MonoBehaviour
    {
        private static IServiceLocator instance;

        private void OnEnable() => DontDestroyOnLoad(this);

        public static IServiceLocator Instance
        {
            get
            {
                if (instance == null) Init();
                return instance;
            }
        }

        private static void Init()
        {
            instance = new ServiceLocator();
        }
    }
}
using System;
using System.Collections.Generic;

namespace JustMobyTest.ServiceLocator
{
    public class ServiceLocator : IServiceLocator
    {
        private readonly Dictionary<Type, object> registeredObjects = new Dictionary<Type, object>();
        
        public void Add<T>(T obj)
        {
            if (obj == null) return;
            Type type = typeof(T);
            if (!registeredObjects.ContainsKey(type)) registeredObjects[type] = obj;
        }

        public T Get<T>()
        {
            Type type = typeof(T);
            if (registeredObjects.ContainsKey(type)) return (T)registeredObjects[type];
            throw new Exception($"Object {type.Name} not registered");
        }
    }
}
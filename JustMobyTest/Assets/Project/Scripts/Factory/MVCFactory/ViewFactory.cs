using UnityEngine;
using Object = UnityEngine.Object;

namespace JustMobyTest.Factory
{
    public class ViewFactory<TView> 
        where TView : MonoBehaviour, IView
    {
        public TView CreateView(GameObject prefab, Transform parent)
        {
            if (prefab == null)
            {
                Debug.LogError($"Prefab in ViewFactory is Empty!");
                return null;
            }
            
            GameObject viewInstance = Object.Instantiate(prefab, parent.transform);
            
            TView view = viewInstance.GetComponent<TView>();
            if (view == null) Debug.LogError("Prefab does not implement the required IView interface.");
            return view;
        }
    }
}
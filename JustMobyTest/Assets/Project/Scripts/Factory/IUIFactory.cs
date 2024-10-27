using UnityEngine;

namespace JustMobyTest.Factory
{
    public interface IUIFactory
    {
        public Canvas CreateCanvas();
        public void CreateWindow<V>() where V : IView;
    }
}
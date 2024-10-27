using System;
using System.Linq;
using JustMobyTest.Factory.Configs;
using JustMobyTest.ServiceLocator;
using JustMobyTest.UI;
using JustMobyTest.UI.Window;
using UnityEngine;
using Object = UnityEngine.Object;

namespace JustMobyTest.Factory
{
    public class UIFactory : IUIFactory
    {
        private readonly UIFactoryConfig factoryConfig;

        private readonly Canvas canvas;
        
        public UIFactory(UIFactoryConfig factoryConfig)
        {
            this.factoryConfig = factoryConfig;
            ServiceLocatorComponent.Instance.Add<IUIFactory>(this);
            canvas = CreateCanvas();
        }
        
        public Canvas CreateCanvas()
        {
            Canvas canvasPrefab = factoryConfig.canvasPrefab;
            return Object.Instantiate(canvasPrefab);
        }

        public void CreateWindow<V>() where V : IView 
        {
            Type viewType = typeof(V);
            
            WindowView prefab = factoryConfig.windowPrefabs.FirstOrDefault(x => x.GetType() == viewType);

            ModelFactory<PurchaseWindowModel> modelFactory = new ModelFactory<PurchaseWindowModel>();
            ViewFactory<PurchaseWindowView> viewFactory = new ViewFactory<PurchaseWindowView>();
            ControllerFactory<PurchaseWindowController> controllerFactory =
                new ControllerFactory<PurchaseWindowController>();

            PurchaseWindowModel model = modelFactory.CreateModel();
            PurchaseWindowView view = viewFactory.CreateView(prefab.gameObject, canvas.transform);
            PurchaseWindowController controller = controllerFactory.CreateController();
            view.Init(model);
            controller.Init(model, view);
            model.Init();
        }
    }
}
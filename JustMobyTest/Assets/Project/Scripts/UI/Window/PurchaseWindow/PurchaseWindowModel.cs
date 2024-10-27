using System;
using JustMobyTest.Data;
using JustMobyTest.ServiceLocator;

namespace JustMobyTest.UI
{
    public class PurchaseWindowModel : IModel
    {
        private PurchaseWindowData data;
        public Action<PurchaseWindowData> OnInitialize;
        
        public PurchaseWindowModel() => data = ServiceLocatorComponent.Instance.Get<PurchaseWindowData>();

        public void Init() => OnInitialize?.Invoke(data);

        public float GetPriceWithDiscount()
        {
            return data.price * (1 - (float)data.discount / 100);
        }

        public void TryPurchase()
        {
            
        }
    }
}
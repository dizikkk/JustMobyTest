using System;
using UnityEngine;

namespace JustMobyTest.UI
{
    public class PurchaseWindowController: IController, IDisposable
    {
        private PurchaseWindowModel model;
        private PurchaseWindowView view;
        
        public void Init(IModel model, IView view)
        {
            this.model = (PurchaseWindowModel)model;
            this.view = (PurchaseWindowView)view;
            this.view.PurchaseButtonClicked += HandleButtonClick;
        }

        private void HandleButtonClick()
        {
            model.TryPurchase();
            Debug.Log("Purchase!");
        }

        public void Dispose() => view.PurchaseButtonClicked += HandleButtonClick;
    }
}
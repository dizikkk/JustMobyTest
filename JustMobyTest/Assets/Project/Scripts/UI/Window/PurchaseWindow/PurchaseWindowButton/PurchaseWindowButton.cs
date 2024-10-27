using System;
using UnityEngine;
using UnityEngine.UI;

namespace JustMobyTest.UI
{
    public class PurchaseWindowButton : MonoBehaviour
    {
        [SerializeField]
        private PriceUIElement priceUIElement;
        
        [SerializeField]
        private DiscountUIElement discountUIElement;

        [SerializeField]
        private Button button;

        public Action ButtonClicked;
        
        public void Init(float price, int discount = 0, float priceWithDiscount = 0f)
        {
            priceUIElement.RefreshPrice(price, discount, priceWithDiscount);
            discountUIElement.RefreshDiscount(discount);
            button.onClick.AddListener(HandleButtonClick);
        }

        private void HandleButtonClick()
        {
            ButtonClicked?.Invoke();
        }

        private void OnDisable() => button.onClick.RemoveAllListeners();
    }
}
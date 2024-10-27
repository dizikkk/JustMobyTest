using System.Globalization;
using TMPro;
using UnityEngine;

namespace JustMobyTest.UI
{
    public class PriceUIElement : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI defaultPriceText;
        
        [SerializeField]
        private TextMeshProUGUI priceTextWithDiscount;
        
        public void RefreshPrice(float price, int discount, float priceWithDiscount)
        {
            SetDefaultPriceState(price);
            if (discount == 0) return;
            SetPriceWithDiscountState(priceWithDiscount);
        }

        private void SetDefaultPriceState(float price)
        {
            defaultPriceText.fontSize = 30f;
            defaultPriceText.color = Color.white;
            defaultPriceText.fontStyle = FontStyles.Normal;
            defaultPriceText.text = $"{price:0.00}$";
            priceTextWithDiscount.gameObject.SetActive(false);
        }

        private void SetPriceWithDiscountState(float priceWithDiscount)
        {
            defaultPriceText.fontSize = 25f;
            defaultPriceText.color = new Color(152f, 152f, 152f);
            defaultPriceText.fontStyle = FontStyles.Strikethrough;
            
            priceTextWithDiscount.gameObject.SetActive(true);
            priceTextWithDiscount.text = $"{priceWithDiscount}$";
        }
    }
}
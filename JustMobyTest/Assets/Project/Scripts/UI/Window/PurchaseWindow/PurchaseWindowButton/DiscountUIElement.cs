using TMPro;
using UnityEngine;

namespace JustMobyTest.UI
{
    public class DiscountUIElement : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI discountText;

        public void RefreshDiscount(int discount)
        {
            if (discount <= 0)
            {
                gameObject.SetActive(false);
                return;
            }
            discountText.text = $"-{discount.ToString()}$";
        }
    }
}
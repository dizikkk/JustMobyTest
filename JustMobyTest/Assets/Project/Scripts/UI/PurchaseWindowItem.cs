using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JustMobyTest.UI
{
    public class PurchaseWindowItem : MonoBehaviour
    {
        [SerializeField]
        private Image icon;

        [SerializeField]
        private TextMeshProUGUI countText;

        public void Init(Sprite icon, int count)
        {
            this.icon.sprite = icon;
            this.countText.text = count.ToString();
        }
    }
}
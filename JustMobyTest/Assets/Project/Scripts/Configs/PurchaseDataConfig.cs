using JustMobyTest.Items;
using UnityEngine;

namespace JustMobyTest.Configs
{
    [CreateAssetMenu(fileName = "PurchaseDataConfig", menuName = "PurchaseData/New PurchaseDataConfig", order = 0)]
    public class PurchaseDataConfig : ScriptableObject
    {
        public string headerText;
        public string descriptionText;
        public SerializableDictionary<ItemType, int> purchaseItems;
        public float price;
        public int discount;
        public string mainIconName;
    }
}
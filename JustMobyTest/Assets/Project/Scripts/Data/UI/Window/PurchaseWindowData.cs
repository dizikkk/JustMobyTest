using JustMobyTest.Configs;
using JustMobyTest.Items;

namespace JustMobyTest.Data
{
    public class PurchaseWindowData
    {
        public readonly string headerText;
        public readonly string descriptionText;
        public readonly SerializableDictionary<ItemType, int> purchaseItems;
        public readonly float price;
        public readonly int discount;
        public readonly string mainIconName;

        public PurchaseWindowData(PurchaseDataConfig config)
        {
            headerText = config.headerText;
            descriptionText = config.descriptionText;
            purchaseItems = config.purchaseItems;
            price = config.price;
            discount = config.discount;
            mainIconName = config.mainIconName;
        }
    }
}
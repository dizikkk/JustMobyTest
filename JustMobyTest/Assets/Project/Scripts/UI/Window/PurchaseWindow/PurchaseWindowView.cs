using System;
using JustMobyTest.Configs;
using JustMobyTest.Data;
using JustMobyTest.Items;
using JustMobyTest.UI.Window;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

namespace JustMobyTest.UI
{
    public class PurchaseWindowView : WindowView, IView
    {
        [SerializeField]
        private Configs configs;
        
        [SerializeField]
        private WindowText windowText;

        [SerializeField]
        private WindowIcons windowIcons;
        
        [SerializeField]
        private PurchaseWindowItems purchaseWindowItems;
        
        [SerializeField]
        private WindowButton windowButton;

        private PurchaseWindowModel windowModel;

        public Action PurchaseButtonClicked;
        
        public void Init(IModel windowModel)
        {
            this.windowModel = (PurchaseWindowModel)windowModel;
            this.windowModel.OnInitialize += Refresh;
        }

        private void Refresh(PurchaseWindowData data)
        {
            windowIcons.SetMainIcon(configs.GetSpriteByName(data.mainIconName));
            windowText.SetWindowText(data);
            purchaseWindowItems.ShowPurchaseItemsFromData(data, configs);
            windowButton.RefreshPurchaseWindowButton(data.price, data.discount, windowModel.GetPriceWithDiscount());
            windowButton.Get().ButtonClicked += HandleButtonClick;
        }

        private void HandleButtonClick()
        {
            PurchaseButtonClicked?.Invoke();
        }
        
        private void OnDestroy()
        {
            windowModel.OnInitialize -= Refresh;
        }

        [Serializable]
        private class Configs
        {
            [SerializeField]
            private IconByNameConfig iconByNameConfig;
        
            [SerializeField]
            private IconByTypeConfig iconByTypeConfig;

            public Sprite GetSpriteByName(string name) => iconByNameConfig.iconsByName[name];
            public Sprite GetSpriteByType(ItemType type) => iconByTypeConfig.iconsByType[type];
        }
        
        [Serializable]
        private class WindowIcons
        {
            [SerializeField]
            private Image mainIcon;
            
            public void SetMainIcon(Sprite icon)
            {
                mainIcon.sprite = icon;
                ChangeIconName(icon.name);
            }

            private void ChangeIconName(string name) => mainIcon.gameObject.name = name;
        }

        [Serializable]
        private class WindowText
        {
            [SerializeField]
            private TextMeshProUGUI headerText;
        
            [SerializeField]
            private TextMeshProUGUI descriptionText;

            public void SetWindowText(PurchaseWindowData data)
            {
                headerText.text = data.headerText;
                descriptionText.text = data.descriptionText;
            }
        }

        [Serializable]
        private class PurchaseWindowItems
        {
            [SerializeField]
            private PurchaseWindowItem[] purchaseWindowItems;

            public void ShowPurchaseItemsFromData(PurchaseWindowData data, Configs configs)
            {
                HideAllItems();
                int index = 0;
                foreach (var item in data.purchaseItems)
                {
                    purchaseWindowItems[index].gameObject.SetActive(true);
                    purchaseWindowItems[index].Init(configs.GetSpriteByType(item.Key), item.Value);
                    index++;
                }
            }

            private void HideAllItems()
            {
                for (int i = 0; i < purchaseWindowItems.Length; i++) purchaseWindowItems[i].gameObject.SetActive(false);
            }
        }

        [Serializable]
        private class WindowButton
        {
            [SerializeField] 
            private PurchaseWindowButton purchaseWindowButton;

            public PurchaseWindowButton Get() => purchaseWindowButton;
            
            public void RefreshPurchaseWindowButton(float price, int discount, float priceWithDiscount) => 
                purchaseWindowButton.Init(price, discount, priceWithDiscount);
        }
    }
}
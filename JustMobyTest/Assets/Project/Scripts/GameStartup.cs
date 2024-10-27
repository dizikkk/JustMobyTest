using System;
using JustMobyTest.Configs;
using JustMobyTest.Data;
using JustMobyTest.Factory;
using JustMobyTest.Factory.Configs;
using JustMobyTest.UI;
using UnityEngine;

namespace JustMobyTest
{
    public class GameStartup : MonoBehaviour
    {
        [SerializeField]
        private GameConfig gameConfig;

        [SerializeField]
        private GameFactory gameFactory;
        
        private void Start()
        {
            GameData gameData = new GameData(gameConfig);
            gameData.Init();

            gameFactory.Init();
            ShowPurchaseWindow();
        }

        private void ShowPurchaseWindow()
        {
            gameFactory.CreatePurchaseWindow();
        }
        
        [Serializable]
        private class GameFactory
        {
            [SerializeField]
            private UIFactoryConfig uiFactoryConfig;

            private IUIFactory uiFactory;
            
            public void Init() => uiFactory = new UIFactory(uiFactoryConfig);

            public void CreatePurchaseWindow() => 
                uiFactory.CreateWindow<PurchaseWindowView>();
        }
    }
}
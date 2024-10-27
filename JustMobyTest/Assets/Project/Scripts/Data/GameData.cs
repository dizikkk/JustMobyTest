using JustMobyTest.Configs;
using JustMobyTest.ServiceLocator;

namespace JustMobyTest.Data
{
    public class GameData
    {
        private readonly GameConfig gameConfig;

        public GameData(GameConfig gameConfig) => this.gameConfig = gameConfig;

        public void Init() => LoadData();

        private void LoadData()
        {
            PurchaseWindowData purchaseWindowData = new PurchaseWindowData(gameConfig.purchaseDataConfig);
            ServiceLocatorComponent.Instance.Add(purchaseWindowData);
        }
    }
}
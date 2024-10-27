using UnityEngine;

namespace JustMobyTest.Configs
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "GameConfig/New GameConfig", order = 0)]
    public class GameConfig : ScriptableObject
    {
        public PurchaseDataConfig purchaseDataConfig;
    }
}
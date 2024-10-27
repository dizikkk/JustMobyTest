using JustMobyTest.UI.Window;
using UnityEngine;

namespace JustMobyTest.Factory.Configs
{
    [CreateAssetMenu(fileName = "UIFactoryConfig", menuName = "Factory/New UIFactoryConfig", order = 0)]
    public class UIFactoryConfig : ScriptableObject
    {
        public Canvas canvasPrefab;
        public WindowView[] windowPrefabs;
    }
}
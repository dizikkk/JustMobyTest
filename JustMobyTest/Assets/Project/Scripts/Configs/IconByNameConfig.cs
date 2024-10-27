using UnityEngine;

namespace JustMobyTest.Configs
{
    [CreateAssetMenu(fileName = "IconByNameConfig", menuName = "PurchaseItems/New IconByNameConfig", order = 0)]
    public class IconByNameConfig : ScriptableObject
    {
        public SerializableDictionary<string, Sprite> iconsByName;
    }
}
using JustMobyTest.Items;
using UnityEngine;

namespace JustMobyTest.Configs
{
    [CreateAssetMenu(fileName = "IconByTypeConfig", menuName = "PurchaseItems/New IconByTypeConfig", order = 0)]
    public class IconByTypeConfig : ScriptableObject
    {
        public SerializableDictionary<ItemType, Sprite> iconsByType;
    }
}
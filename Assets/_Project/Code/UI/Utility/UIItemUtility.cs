using Game.Gameplay;
using UnityEngine;

namespace Game.UI.Utility
{
    public class UIItemUtility
    {
        public static string GetIconKey(string id)
        {
            return $"item/{id}";
        }

        public static string GetRandomItem()
        {
            var i = Random.Range(0, 6);
            
            switch (i)
            {
                case 1: return ItemType.WOOD;
                case 2: return ItemType.GRASS;
                case 3: return ItemType.ROPE;
                case 4: return ItemType.COAL;
                case 5: return ItemType.STONE;
            }

            return ItemType.GOLD;
        }
    }
}
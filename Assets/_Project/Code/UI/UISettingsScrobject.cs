using UnityEngine;

namespace Game.UI
{
    [CreateAssetMenu(menuName = "Game/UI/Settings", fileName = "UISettings")]
    public class UISettingsScrobject : ScriptableObject
    {
        public UISettings settings;
    }
}
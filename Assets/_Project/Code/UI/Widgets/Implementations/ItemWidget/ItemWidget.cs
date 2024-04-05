using Game.Gameplay;
using Game.UI.Utility;
using UnityEngine;

namespace Game.UI.Widgets
{
    public class ItemWidget : UIElement<ItemWidgetLayout>
    {
        private IconsDatabase _icons;

        public ItemWidget(ItemWidgetLayout layout, IconsDatabase icons) : base(layout)
        {
            _icons = icons;
        }

        public void Update(ItemContainer container)
        {
            var key = UIItemUtility.GetIconKey(container.item);
            UpdateIcon(key);
            UpdateAmount(container.amount);
        }

        private void UpdateIcon(string iconKey)
        {
            if (_icons.TryGetValue(iconKey, out var sprite))
            {
                UpdateIcon(sprite);
            }
            else
            {
                layout.icon.gameObject.SetActive(false);
            }
        }

        private void UpdateIcon(Sprite sprite)
        {
            layout.icon.gameObject.SetActive(true);
            layout.icon.sprite = sprite;
        }

        private void UpdateAmount(int itemAmount)
        {
            layout.amount.gameObject.SetActive(itemAmount > 0);

            layout.amount.text = itemAmount.ToString();
        }
    }
}
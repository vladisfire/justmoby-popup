using System.Collections.Generic;
using Game.Gameplay;
using Game.UI.Widgets;
using Object = UnityEngine.Object;

namespace Game.UI
{
    public class SpecialOfferPopup : UIPopup<SpecialOfferPopupLayout>
    {
        private IconsDatabase _icons;

        //Can use a pool
        private List<ItemWidget> _widgets = new List<ItemWidget>();

        public SpecialOfferPopup(SpecialOfferPopupLayout layout, IconsDatabase icons) : base(layout)
        {
            _icons = icons;
        }

        protected override void OnInitialized()
        {
            layout.button.onClick.AddListener(HandleClicked);
        }

        protected override void OnDispose()
        {
            layout.button.onClick.RemoveListener(HandleClicked);
        }

        public void Show(SpecialOfferPopupArgs args)
        {
            UpdateTitle(args.title);
            UpdateDescription(args.description);
            UpdateIcon(args.icon);
            UpdateItems(args.items);
            UpdatePrice(args.price, args.discount);

            Show();
        }

        private void UpdateItems(ItemContainer[] containers)
        {
            for (int i = 0; i < _widgets.Count; i++)
            {
                _widgets[i].Hide();
            }

            for (int i = 0; i < containers.Length; i++)
            {
                var container = containers[i];

                if (i >= _widgets.Count)
                    CreateItemWidget();

                _widgets[i].Show();
                _widgets[i].Update(container);
            }
        }

        private void UpdateIcon(string key)
        {
            layout.icon.gameObject.SetActive(false);

            if (_icons.TryGetValue(key, out var sprite))
            {
                layout.icon.gameObject.SetActive(true);
                layout.icon.sprite = sprite;
            }
        }

        private void UpdateTitle(string text)
        {
            layout.title.text = text;
        }

        private void UpdateDescription(string text)
        {
            layout.description.text = text;
        }

        private void UpdatePrice(decimal price, float discount)
        {
            var isSale = discount > 0;
            layout.discountParent.gameObject.SetActive(isSale);
            layout.discountText.text = $"-{discount:P}";

            layout.price.text = $"${price:F2}";

            layout.oldPrice.gameObject.SetActive(isSale);
            var oldPrice = price + (decimal) (discount) * price;
            layout.oldPrice.text = $"${oldPrice:F2}";
        }

        private ItemWidget CreateItemWidget()
        {
            var widgetLayout = Object.Instantiate(layout.itemWidgetPrefab, layout.itemsParent.transform);
            var widget = new ItemWidget(widgetLayout, _icons);

            _widgets.Add(widget);
            return widget;
        }

        private void HandleClicked()
        {
            Hide();
        }
    }

    public struct SpecialOfferPopupArgs
    {
        public string title;
        public string description;
        public string icon;
        public ItemContainer[] items;
        public decimal price;
        public float discount;
    }
}
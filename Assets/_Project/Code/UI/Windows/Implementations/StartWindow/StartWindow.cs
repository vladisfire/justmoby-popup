using System;
using System.Collections.Generic;
using Game.Gameplay;
using Game.UI.Utility;
using Random = UnityEngine.Random;

namespace Game.UI
{
    public class StartWindow : UIWindow<StartWindowLayout>
    {
        private SpecialOfferPopup _popup;

        public StartWindow(StartWindowLayout layout, SpecialOfferPopup popup) : base(layout)
        {
            _popup = popup;
        }

        protected override void OnInitialized()
        {
            layout.button.onClick.AddListener(HandleClick);
            layout.inputField.onValueChanged.AddListener(HandleValueChanged);
        }

        protected override void OnDispose()
        {
            layout.button.onClick.RemoveListener(HandleClick);
            layout.inputField.onValueChanged.RemoveListener(HandleValueChanged);
        }

        private void HandleClick()
        {
            if (!Int32.TryParse(layout.inputField.text, out var amount)) return;

            var list = new List<ItemContainer>();
            for (int i = 0; i < amount; i++)
            {
                list.Add(new ItemContainer
                {
                    amount = UnityEngine.Random.Range(0, 100),
                    item = UIItemUtility.GetRandomItem()
                });
            }

            var icon = UIItemUtility.GetIconKey(UIItemUtility.GetRandomItem());
            
            _popup.Show(new SpecialOfferPopupArgs
            {
                title = $"Title",
                description = "Description",
                items = list.ToArray(),
                icon = icon,
                price = (decimal) Random.Range(0.99f, 10),
                discount = Random.Range(0, 100) * 0.01f,
            });
        }

        private void HandleValueChanged(string text)
        {
            if (Int32.TryParse(layout.inputField.text, out var amount))
            {
                if (amount < 0)
                {
                    layout.inputField.text = 0.ToString();
                }

                if (amount > 6)
                {
                    layout.inputField.text = 6.ToString();
                }
            }
            else
            {
                layout.inputField.text = string.Empty;
            }
        }
    }
}
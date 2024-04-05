using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class SpecialOfferPopupLayout : UILayout
    {
        [Space]
        public TMP_Text title;

        public TMP_Text description;
        public Image icon;

        [Space]
        public LayoutGroup itemsParent;

        public ItemWidgetLayout itemWidgetPrefab;

        [Space]
        public Button button;


        public RectTransform discountParent;
        public TMP_Text discountText;

        public TMP_Text price;
        public TMP_Text oldPrice;
    }
}
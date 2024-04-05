using Game.UI;
using UnityEngine;

namespace Game
{
    public class Bootstrap
    {
        private const string CANVAS_TAG = "Canvas";

        public const string CONFIG_PATH = "UISettings";

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public static void Boot()
        {
            var scrobject = Resources.Load<UISettingsScrobject>(CONFIG_PATH);

            var canvas = GameObject.FindGameObjectWithTag(CANVAS_TAG);

            var popupLayout = Object.Instantiate(scrobject.settings.popups.specialOffer, canvas.transform);
            popupLayout.gameObject.SetActive(false);
            var popup = new SpecialOfferPopup(popupLayout, scrobject.settings.icons);

            var layout = Object.Instantiate(scrobject.settings.windows.start, canvas.transform);
            var startWindow = new StartWindow(layout, popup);
            layout.gameObject.SetActive(false);

            startWindow.Show();
        }
    }
}
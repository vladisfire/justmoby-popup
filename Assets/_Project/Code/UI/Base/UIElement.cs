using System;

namespace Game.UI
{
    public class UIElement<TLayout> : IDisposable
        where TLayout : UILayout
    {
        private TLayout _layout;

        protected TLayout layout { get { return _layout; } }

        public UIElement(TLayout layout)
        {
            _layout = layout;

            OnInitialized();
        }

        public void Show()
        {
            _layout.gameObject.SetActive(true);
            _layout.transform.SetAsLastSibling();
            
            OnShow();
        }

        public void Hide()
        {
            _layout.gameObject.SetActive(false);

            OnHide();
        }

        public void Dispose()
        {
            OnDispose();
        }

        protected virtual void OnInitialized()
        {
        }

        protected virtual void OnShow()
        {
        }

        protected virtual void OnHide()
        {
        }

        protected virtual void OnDispose()
        {
        }
    }
}
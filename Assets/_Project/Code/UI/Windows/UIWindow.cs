namespace Game.UI
{
    public class UIWindow<TLayout> : UIElement<TLayout> where TLayout : UILayout
    {
        public UIWindow(TLayout layout) : base(layout)
        {
        }
    }
}
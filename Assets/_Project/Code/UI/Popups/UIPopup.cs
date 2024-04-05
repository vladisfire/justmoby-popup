namespace Game.UI
{
    public class UIPopup<TLayout> : UIElement<TLayout>
        where TLayout : UILayout
    {
        public UIPopup(TLayout layout) : base(layout)
        {
        }
    }
}
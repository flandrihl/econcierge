using System.Drawing;
using CustomControls.Atm;

namespace TouchControls.ControlHandlers
{
    public class AtmItemHandler : ElementHandler
    {
        public override void Tap(PointF global, PointF relative)
        {
            var c = Source as AtmItem;
            if (c == null) return;
            c.Tapped();
            base.Tap(global, relative);
        }
    }
}
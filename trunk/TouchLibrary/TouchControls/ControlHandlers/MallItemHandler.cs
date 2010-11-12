using System.Drawing;
using CustomControls.Mall;

namespace TouchControls.ControlHandlers
{
    public class MallItemHandler : ElementHandler
    {
        public override void Tap(PointF global, PointF relative)
        {
            var c = Source as MallItem;
            if (c == null) return;
            c.Tapped();
            base.Tap(global, relative);
        }
    }
}
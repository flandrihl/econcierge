using System.Drawing;
using CustomControls.Cafe;

namespace TouchControls.ControlHandlers
{
    public class CafeItemHandler : ElementHandler
    {
        public override void Tap(PointF global, PointF relative)
        {
            var c = Source as CafeItem;
            if (c == null) return;
            c.Tapped();
            base.Tap(global, relative);
        }
    }
}
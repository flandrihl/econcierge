using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;
using eConcierge.Foundation.Applications.Presenters;
using eConcierge.Foundation.Applications.Views;
using eConcierge.Resort.Applications.Views;

namespace eConcierge.Resort.Applications.Presenters
{
    [Export(typeof(VideoToolPresenter))]
    public class VideoToolPresenter : ABaseToolPresenter
    {
        [ImportingConstructor]
        public VideoToolPresenter(IBaseToolView view, IVideoToolView body)
            : base(view, null, null, body)
        {
            TitleVisibility = Visibility.Collapsed;
            DescriptionVisibility = Visibility.Collapsed;
        }
    }
}

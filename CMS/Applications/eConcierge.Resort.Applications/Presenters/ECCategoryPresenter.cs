using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using eConcierge.Foundation.Applications.Presenters;
using eConcierge.Foundation.Views;
using eConcierge.Resort.Applications.Views;

namespace eConcierge.Resort.Applications.Presenters
{
    [Export(typeof(ECCategoryPresenter))]
    public class ECCategoryPresenter : ADialogContentPresenter
    {
         [ImportingConstructor]
        public ECCategoryPresenter(IECCategoryView body)
            : base(body)
        {
  
        }
    }
}

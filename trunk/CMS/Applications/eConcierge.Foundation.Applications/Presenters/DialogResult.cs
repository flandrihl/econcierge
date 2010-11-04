using System;

namespace eConcierge.Foundation.Applications.Presenters
{
    [Flags]
    public enum DialogResult
    {
        Default = 0,
        OK = 1,
        Cancel = 2,
        Yes = 4,
        No = 8,
        Ignore = 16,
        Abort = 32,
        Retry = 64
    }
}

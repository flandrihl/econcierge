using System;

namespace eConcierge.Foundation.Applications.Presenters
{
    [Flags]
    public enum DialogButton
    {
        // Summary:
        //     The message box contains no button.
        None = 0,
        // Summary:
        //     The message box contains an OK button.
        OK = 1,
        //
        // Summary:
        //     The message box contains OK and Cancel buttons.
        OKCancel = 2,
        //
        // Summary:
        //     The message box contains Abort, Retry, and Ignore buttons.
        AbortRetryIgnore = 3,
        //
        // Summary:
        //     The message box contains Yes, No, and Cancel buttons.
        YesNoCancel = 4,
        //
        // Summary:
        //     The message box contains Yes and No buttons.
        YesNo = 5,
        //
        // Summary:
        //     The message box contains Retry and Cancel buttons.
        RetryCancel = 6,
    }
}
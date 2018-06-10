// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace ProfitLossCalculator
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton CalculateButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField EntryTxtField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField PrincipalTxtField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ResultLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TargetTxtField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView TradeImage { get; set; }

        [Action ("CalculateButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CalculateButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (CalculateButton != null) {
                CalculateButton.Dispose ();
                CalculateButton = null;
            }

            if (EntryTxtField != null) {
                EntryTxtField.Dispose ();
                EntryTxtField = null;
            }

            if (PrincipalTxtField != null) {
                PrincipalTxtField.Dispose ();
                PrincipalTxtField = null;
            }

            if (ResultLabel != null) {
                ResultLabel.Dispose ();
                ResultLabel = null;
            }

            if (TargetTxtField != null) {
                TargetTxtField.Dispose ();
                TargetTxtField = null;
            }

            if (TradeImage != null) {
                TradeImage.Dispose ();
                TradeImage = null;
            }
        }
    }
}
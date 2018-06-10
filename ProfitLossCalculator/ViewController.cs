using System;
using Foundation;
using UIKit;
using System.Diagnostics;
namespace ProfitLossCalculator
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            //dismiss the keyboard on background touch
            View.AddGestureRecognizer(new UITapGestureRecognizer(() =>
            {
                PrincipalTxtField.ResignFirstResponder();
                EntryTxtField.ResignFirstResponder();
                TargetTxtField.ResignFirstResponder();
            }));
        }

        partial void CalculateButton_TouchUpInside(UIButton sender)
        {
            CheckEmpty();

            /*             Calculate profits             */
            //get number of shares
            double entry = Double.Parse(EntryTxtField.Text);
            double exit = Double.Parse(TargetTxtField.Text);
            double principal = Double.Parse(PrincipalTxtField.Text);
            Calculate.NumberOfShares = principal / entry;
            double profit = Calculate.CalculateProfit(entry, exit);

            ResultLabel.Text = profit > 0 ? $"Profit: {Settings.Currency}{profit}," : $"Loss: {Settings.Currency}{profit},";
            ResultLabel.Text += $" Return: {Calculate.CalculateROI(exit, principal)}%";


            /*           Add to history                 */

            //CalculationHistory.AddData()
        }

        private void CheckEmpty()
        {
            if (EntryTxtField.Text == "")
                EntryTxtField.Text = "0";

            if (PrincipalTxtField.Text == "")
                PrincipalTxtField.Text = "0";

            if (TargetTxtField.Text == "")
                TargetTxtField.Text = "0";
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

    }
}

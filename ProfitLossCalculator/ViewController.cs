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

            //set image to up market
             
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


            // flip image for according to profit
            if (profit < 0)
            {
                TradeImage.Image = UIImage.FromBundle("Down-Market");
                ResultLabel.Text = $"Loss: {Settings.Currency}{profit:0.00}, " +
                    $"ROI: {Calculate.CalculateROI(exit, entry):0}%";
            }
            else
            {
                TradeImage.Image = UIImage.FromBundle("Up-Market");
                ResultLabel.Text = $"Profit: {Settings.Currency}{profit:0.00}, " +
                    $"ROI: {Calculate.CalculateROI(exit, entry):0}%";
            }



            /*           Add to history                 */

            // first param is cell title, second is subtitle
            string title = $"Principal: {principal}, Entry: {entry}, Exit: {exit}";
            CalculationHistory.AddData(title, ResultLabel.Text); 

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

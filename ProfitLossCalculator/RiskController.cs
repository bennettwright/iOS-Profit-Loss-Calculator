using Foundation;
using System;
using UIKit;

namespace ProfitLossCalculator
{
    public partial class RiskController : UIViewController
    {
        public RiskController (IntPtr handle) : base (handle)
        {
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
                StopLTxtField.ResignFirstResponder();
            }));

        }

        partial void CalculateButton_TouchUpInside(UIButton sender)
        {
            /*             Calculate profits             */
            //get number of shares
            CheckEmpty();
            double entry = Double.Parse(EntryTxtField.Text);
            double principal = Double.Parse(PrincipalTxtField.Text);
            Calculate.NumberOfShares = principal / entry;

            double exit = Double.Parse(TargetTxtField.Text);
            double stop = Double.Parse(StopLTxtField.Text);
            double profit = Calculate.CalculateProfit(entry, exit);
            double ROI = Calculate.CalculateROI(exit, principal);

            string rewardRatio = Calculate.CalculateRiskRewardRatio(entry, exit, stop);

            ResultLabel.Text = profit > 0 ? $"Profit: {Settings.Currency}{profit}," : $"Loss: {Settings.Currency}{profit},";
            ResultLabel.Text += $" {rewardRatio}, ROI: {Calculate.CalculateROI(exit, principal)}%";

            string info1 = $"Entry: {entry}, Target: {exit}, Stop: {stop}";
            string info2 = $"Profit: {Settings.Currency}{profit}, {rewardRatio}, ROI: {ROI}";
            CalculationHistory.AddData(info1, info2);
        }

        private void CheckEmpty()
        {
            if (EntryTxtField.Text == "")
                EntryTxtField.Text = "0";
            
            if (StopLTxtField.Text == "")
                StopLTxtField.Text = "0";
            
            if (PrincipalTxtField.Text == "")
                PrincipalTxtField.Text = "0";

            if (TargetTxtField.Text == "")
                TargetTxtField.Text = "0";
        }

    }
}
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
            double numShares = principal / entry;
            double exit = Double.Parse(TargetTxtField.Text);
            double stop = Double.Parse(StopLTxtField.Text);
            double profit = Calculate.CalculateProfit(entry, exit, numShares);
            double ROI = Calculate.CalculateROI(exit, entry);

            string rewardRatio = Calculate.CalculateRiskRewardRatio(entry, exit, stop, numShares);


            ResultLabel.Text = $"Profit: {Settings.Currency}{profit:0.00}, {rewardRatio}, ROI: {ROI:0}%";

            string info1 = $"Entry: {entry}, Target: {exit}, Stop: {stop}";
            CalculationHistory.AddData(info1, ResultLabel.Text);
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
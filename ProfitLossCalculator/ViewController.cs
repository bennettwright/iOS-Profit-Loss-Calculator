﻿using System;
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

            ResultLabel.Text = $"Profit: {Settings.Currency}{profit}, ROI: {Calculate.CalculateROI(exit, principal)}%";


            /*           Add to history                 */

            string title = $"Principal: {principal}, Entry: {entry}, Exit: {exit}"; // cell title
            CalculationHistory.AddData(title, ResultLabel.Text); // textbox is subtitle 
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

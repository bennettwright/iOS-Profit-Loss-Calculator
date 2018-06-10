using System;
using Foundation;
using UIKit;

namespace ProfitLossCalculator
{
    public class Settings
    {
        public static string Currency
        {
            get => CheckSettings();
        }

        private static string  CheckSettings()
        {
            NSUserDefaults defaults = NSUserDefaults.StandardUserDefaults;
            return defaults.StringForKey("currency_pref");
        }
    }
}

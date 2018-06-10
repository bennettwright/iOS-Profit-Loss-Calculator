using System;
namespace ProfitLossCalculator
{
    public class Calculate
    {
        public Calculate()
        {
        }

        public static double NumberOfShares { get; set; }

        public static double CalculateProfit(double entry, double exit) => (exit - entry) * NumberOfShares;

        public static double CalculateROI(double exit, double principal) => ((exit - principal) /100) * 100;

        //calculates risk:reward ratio
        public static string CalculateRiskRewardRatio(double entry, double target, double stop)
        {
            double maxLoss = (entry - stop) * NumberOfShares; // get max loss using stop
            if (maxLoss == 0) return "0";
            double risk = CalculateProfit(entry, target) / maxLoss; // get net profit and divide by max loss
            return $"Risk: {risk:0.00}:1";
        }

        private static void AddToHistory(string data)
        {
            
        }
    }
}

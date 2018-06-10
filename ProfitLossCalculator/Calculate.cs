using System;
namespace ProfitLossCalculator
{
    public class Calculate
    {
        //public static double NumberOfShares { get; set; }

        public static double CalculateProfit(double entry, double exit, double numShares) => (exit - entry) * numShares;

        public static double CalculateROI(double exit, double entry) => ((exit - entry) /entry) * 100; 

        //calculates risk:reward ratio
        public static string CalculateRiskRewardRatio(double entry, double target, double stop, double numShares)
        {
            double maxLoss = (entry - stop) * numShares; // get max loss using stop
            double reward = CalculateProfit(entry, target, numShares) / maxLoss; // get net profit and divide by max loss
            return $"Risk: {reward:0}:1";
        }
    }
}

using System;

namespace ESMART_HMS.Domain.Utils
{
    public class FormHelper
    {
        public static decimal GetDateInterval(DateTime startDate, DateTime endDate)
        {
            TimeSpan difference = endDate - startDate;
            return Math.Abs(difference.Days);
        }

        public static decimal GetPriceByRateAndTime(DateTime startDate, DateTime endDate, decimal rate)
        {
            decimal timeSpan = GetDateInterval(startDate, endDate);
            return timeSpan * rate;
        }

        public static string FormatNumberWithCommas(decimal number)
        {
            return number.ToString("#,##0.00");
        }

        public static bool TryConvertStringToDecimal(string input, out decimal result)
        {
            return decimal.TryParse(input, out result);
        }

        public static bool AreAnyNullOrEmpty(params string[] args)
        {
            foreach (var arg in args)
            {
                if (string.IsNullOrEmpty(arg))
                {
                    return true;
                }
            }
            return false;
        }

    }
}

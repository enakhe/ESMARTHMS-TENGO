using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Domain.Utils
{
    public class FormHelper
    {
        public decimal GetDateInterval(DateTime startDate, DateTime endDate)
        {
            TimeSpan difference = endDate - startDate;
            return Math.Abs(difference.Days);
        }

        public decimal GetPriceByRateAndTime(DateTime startDate, DateTime endDate, decimal rate)
        {
            decimal timeSpan = GetDateInterval(startDate, endDate);
            return timeSpan * rate;
        }
    }
}

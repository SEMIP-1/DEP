using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Class
{
    public class PercentageDiscount : Discount
    {
        private readonly decimal _percentage;
        public override string Name => $"Percentage ({_percentage}%)";

        public PercentageDiscount(decimal percentage)
        {
            _percentage = percentage;
        }

        public override decimal CalculateDiscount(decimal price, int quantity)
        {
            return price * quantity * (_percentage / 100.0m);
        }
    }
}

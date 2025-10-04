using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Class
{
    public class NoDiscount : Discount
    {
        public override string Name => "None";
        public override decimal CalculateDiscount(decimal price, int quantity)
        {
            return 0m;
        }
    }
}

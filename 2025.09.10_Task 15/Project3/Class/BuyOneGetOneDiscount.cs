using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Class
{
    public class BuyOneGetOneDiscount : Discount
    {
        public override string Name => "Buy One Get One (50%)";
        public override decimal CalculateDiscount(decimal price, int quantity)
        {
            if (quantity < 2) return 0m;
            int discountedItems = quantity / 2;
            return (price / 2.0m) * discountedItems;
        }
    }
}

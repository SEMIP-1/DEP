using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Class
{
    public class FlatDiscount : Discount
    {
        private readonly decimal _flatAmount;
        public override string Name => $"Flat (${_flatAmount})";

        public FlatDiscount(decimal flatAmount)
        {
            _flatAmount = flatAmount;
        }

        public override decimal CalculateDiscount(decimal price, int quantity)
        {
            int effectiveQuantity = quantity > 0 ? 1 : 0;
            return _flatAmount * effectiveQuantity;
        }
    }
}

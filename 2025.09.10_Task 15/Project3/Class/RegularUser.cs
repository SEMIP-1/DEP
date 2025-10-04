using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Class
{
    public class RegularUser : User
    {
        public RegularUser(string name)
        {
            Name = name;
        }
        public override Discount GetDiscount()
        {
            return new PercentageDiscount(5.0m); // 5% discount
        }
    }
}

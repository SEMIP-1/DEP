using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Class
{
    public class PremiumUser : User
    {
        public PremiumUser(string name)
        {
            Name = name;
        }
        public override Discount GetDiscount()
        {
            return new FlatDiscount(100.0m); // $100 flat discount
        }
    }
}

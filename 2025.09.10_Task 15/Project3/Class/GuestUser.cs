using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Class
{
    public class GuestUser : User
    {
        public GuestUser(string name)
        {
            Name = name;
        }
        public override Discount GetDiscount()
        {
            return new NoDiscount(); // No discount
        }
    }
}

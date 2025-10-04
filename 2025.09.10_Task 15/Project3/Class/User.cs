using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Class
{
    public abstract class User
    {
        public string Name { get; protected set; }
        public abstract Discount GetDiscount();
    }
}

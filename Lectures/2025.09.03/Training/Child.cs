using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    internal class Child: Parent 
    {
        public int Z { get; set; }
        public Child(int x, int y, int z) : base(x, y)
        {
            this.Z = z;
        }
        public int ProductXYZ(Child mychild)
        {
            int result = mychild.Z * ProductXY(mychild);
            return result;
        }
    }
}

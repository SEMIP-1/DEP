using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    internal class Parent
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Parent(int x, int y) 
        { 
            this.X = x; 
            this.Y = y;
        }
        public int ProductXY(Parent parent) 
        { 
            int result = parent.X * parent.Y;
            return result;
        }
    }
}

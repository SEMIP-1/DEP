using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    internal class Car
    {
        #region Properties 
        public int Speed { get; set; }
        public string Model { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty; 
        #endregion

        #region Constructors
        public Car() { }
        public Car(string name)
        {
            this.Id = name;
        }
        public Car(string name, string model)
        {
            this.Id = name;
            this.Model = model;
        }
        public Car(string name, string model, int speed)
        {
            this.Id = name;
            this.Model = model;
            this.Speed = speed;
        } 
        #endregion
    }
}

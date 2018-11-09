using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib
{
    public class Car
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public string RegNr { get; set; }

        public Car()
        {
            
        }

        public Car(string model, string color, string regNr)
        {
            Model = model;
            Color = color;
            RegNr = regNr;
        }

        public override string ToString()
        {
            return $"{Model}, {Color}, {RegNr}";
        }
    }
}

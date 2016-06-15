using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticTuningAtelier
{
    public class Car
    {
        string Model { get; }
        int Year { get; }
        string Color { get; set; }

        public Car(string model, int year, string color)
        {
            Model = model;
            Year = year;
            Color = color;
        }

        public Car()
            : this("Toyota", 1996, "Black")
        {
        }

        public void Describe()
        {
            Console.WriteLine(Color + " " + Model + " " + Year.ToString());
        }

        public void ChangeColor(string color)
        {
            Color = color;
        }
    }
}

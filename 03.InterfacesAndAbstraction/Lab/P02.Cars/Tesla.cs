using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        private string model;
        private string color;
        private int battery;

        public Tesla(string model, string color, int battery)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
        }

        public string Model
        {
            get { return model; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Model cannot be empty.");
                }

                model = value;
            }
        }
        public string Color
        {
            get { return color; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Color cannot be empty.");
                }

                color = value;
            }
        }
        public int Battery
        {
            get { return battery; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Batteries cannot be 0 or negative.");
                }

                battery = value;
            }
        }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            return $"{this.Color} Tesla {this.Model} with {this.Battery} Batteries";
        }
    }
}

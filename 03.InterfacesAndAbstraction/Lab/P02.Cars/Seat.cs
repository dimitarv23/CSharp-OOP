using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        private string model;
        private string color;

        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
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
            return $"{this.Color} Seat {this.Model}";
        }
    }
}

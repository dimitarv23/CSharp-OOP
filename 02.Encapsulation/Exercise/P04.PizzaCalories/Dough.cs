using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace P04.PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private int weight;

        private const int @base = 2; //Base calories per gram
        private double modifier;
        private string[] allowedFlours = new string[2] { "white", "wholegrain" };
        private string[] allowedTechniques = new string[3] { "crispy", "chewy", "homemade" };

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get { return flourType; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || !allowedFlours.Contains(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value;
            }
        }
        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || !allowedTechniques.Contains(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = value;
            }
        }
        public int Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                weight = value;
            }
        }
        public double TotalCalories
        {
            get { return this.GetTotalCalories(); }
        }

        private void GetModifier()
        {
            switch (this.FlourType.ToLower())
            {
                case "white": this.modifier = 1.5; break;
                case "wholegrain": this.modifier = 1.0; break;
                default: break;
            }

            switch (this.BakingTechnique.ToLower())
            {
                case "crispy": this.modifier *= 0.9; break;
                case "chewy": this.modifier *= 1.1; break;
                case "homemade": this.modifier *= 1.0; break;
                default: break;
            }
        }
        private double GetTotalCalories()
        {
            this.GetModifier();
            double calories = @base * this.Weight * this.modifier;
            return calories;
        }
    }
}

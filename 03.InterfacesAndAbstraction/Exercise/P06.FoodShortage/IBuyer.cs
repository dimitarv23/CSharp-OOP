using System;
using System.Collections.Generic;
using System.Text;

namespace P06.FoodShortage
{
    public interface IBuyer
    {
        string Name { get; set; }
        int Food { get; set; }
        int BuyFood();
    }
}

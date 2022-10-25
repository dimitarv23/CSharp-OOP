using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Raiding
{
    public abstract class HeroFactory
    {
        public abstract BaseHero GetHero(string name, string type);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Raiding
{
    public class Rogue : BaseHero
    {
        public Rogue(string name) : base(name, 80)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}

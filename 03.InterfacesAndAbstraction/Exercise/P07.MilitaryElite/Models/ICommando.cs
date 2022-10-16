using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite.Models
{
    public interface ICommando : ISpecialisedSoldier
    {
        List<IMission> Missions { get; set; }
    }
}

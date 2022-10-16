using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite.Models
{
    public interface IEngineer : ISpecialisedSoldier
    {
        List<IRepair> Repairs { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite.Models
{
    public interface IRepair
    {
        string PartName { get; set; }
        int HoursWorked { get; set; }
    }
}

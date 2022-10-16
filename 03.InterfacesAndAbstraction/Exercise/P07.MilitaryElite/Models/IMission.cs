using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite.Models
{
    public interface IMission
    {
        string CodeName { get; set; }
        string State { get; set; }
    }
}

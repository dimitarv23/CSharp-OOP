using P07.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite.Objects
{
    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; set; }
        public string State { get; set; }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}

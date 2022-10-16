using System;
using System.Collections.Generic;
using System.Text;

namespace P09.ExplicitInterfaces
{
    public interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }

        string GetName();
    }
}

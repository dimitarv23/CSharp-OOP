﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P09.ExplicitInterfaces
{
    public interface IResident
    {
        string Name { get; set; }
        string Country { get; set; }

        string GetName();
    }
}

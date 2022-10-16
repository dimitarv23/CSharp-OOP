using System;
using System.Collections.Generic;
using System.Text;

namespace P08.CollectionHierarchy.Models
{
    public interface IAdd
    {
        List<string> Items { get; set; }
        int Add(string element);
    }
}

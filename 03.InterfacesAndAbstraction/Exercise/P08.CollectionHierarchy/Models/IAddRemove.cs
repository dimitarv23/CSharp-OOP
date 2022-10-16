using System;
using System.Collections.Generic;
using System.Text;

namespace P08.CollectionHierarchy.Models
{
    public interface IAddRemove : IAdd
    {
        string Remove();
    }
}

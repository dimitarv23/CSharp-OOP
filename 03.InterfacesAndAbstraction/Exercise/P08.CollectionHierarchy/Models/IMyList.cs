using System;
using System.Collections.Generic;
using System.Text;

namespace P08.CollectionHierarchy.Models
{
    public interface IMyList : IAddRemove
    {
        int Used { get; }
    }
}

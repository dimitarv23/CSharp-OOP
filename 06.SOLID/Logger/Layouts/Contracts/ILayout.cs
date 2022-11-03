using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Layouts.Contracts
{
    public interface ILayout
    {
        string Format { get; }
    }
}

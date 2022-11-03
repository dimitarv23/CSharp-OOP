using Logger.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Layouts
{
    public class SimpleLayout : ILayout
    {
        string ILayout.Format => "{0} - {1} - {2}";
    }
}

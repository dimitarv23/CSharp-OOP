using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite.Models
{
    public interface ILieutenantGeneral : IPrivate
    {
        List<IPrivate> Privates { get; set; }
    }
}

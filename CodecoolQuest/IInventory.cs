using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codecool.Quest
{
    public interface IInventory
    {
        string[] Weapons { get; set; }
        string[] Items { get; set; }
    }
}
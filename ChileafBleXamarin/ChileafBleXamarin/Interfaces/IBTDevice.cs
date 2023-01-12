using System;
using System.Collections.Generic;
using System.Text;

namespace ChileafBleXamarin.Interfaces
{
    public interface IBTDevice
    {
        string Name { get; }
        string Address { get; }
        object Native { get; }
    }
}

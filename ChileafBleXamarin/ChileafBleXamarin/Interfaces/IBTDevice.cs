using System;
using System.Collections.Generic;
using System.Text;

namespace ChileafBleXamarin.Interfaces
{
    public interface IBTDevice
    {
        string Name { get; }
        object Native { get; }
    }
}

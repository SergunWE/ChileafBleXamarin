using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ChileafBleXamarin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChileafBleXamarin.Droid.Chileaf
{
    internal class BTDeviceWrapper : IBTDevice
    {
        private BluetoothDevice _device;

        public BTDeviceWrapper(BluetoothDevice device)
        {
            _device = device;
        }

        public string Name => _device.Name;

        public object Native => _device;
    }
}
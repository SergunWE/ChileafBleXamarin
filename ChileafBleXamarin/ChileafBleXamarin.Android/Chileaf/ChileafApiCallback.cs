using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ChileafBleXamarin.DataTypes;
using ChileafBleXamarin.Interfaces;
using Com.Android.Chileaf.Wear;
using Java.Interop;
using Java.Lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChileafBleXamarin.Droid.Chileaf
{
    internal class ChileafApiCallback : Java.Lang.Object, IWearManagerCallbacks
    {
        public IApiCallback Callback { get; set; }

        public void OnBatteryLevelChanged(BluetoothDevice p0, int p1)
        {
            Callback?.OnBatteryLevelChanged(p1);
        }

        public void OnBodySensorLocationReceived(BluetoothDevice p0, [IntDef(Type = "Com.Android.Chileaf.Fitness.Common.Heart.IBodySensorLocationCallback", Fields = new[] { "SensorLocationOther", "SensorLocationChest", "SensorLocationWrist", "SensorLocationFinger", "SensorLocationHand", "SensorLocationEarLobe", "SensorLocationFoot" })] int p1)
        {
            Callback?.OnBodySensorLocationReceived(p1);
        }

        public void OnDeviceConnected(BluetoothDevice p0)
        {
            Callback?.OnDeviceConnected();
        }

        public void OnDeviceDisconnected(BluetoothDevice p0)
        {
            Callback?.OnDeviceDisconnected();
        }

        public void OnFirmwareVersion(BluetoothDevice p0, string p1)
        {
            //Callback?.OnFirmwareVersion(p1);
        }

        public void OnHardwareVersion(BluetoothDevice p0, string p1)
        {
            //Callback?.OnHardwareVersion(p1);
        }

        public void OnHeartRateMeasurementReceived(BluetoothDevice p0, int p1, Java.Lang.Boolean p2, Integer p3, IList<Integer> p4)
        {
            ChileafHrData data = new ChileafHrData();
            data.HeartRate = p1;
            data.ContactDetected = p2 == null ? null : (bool?)p2;
            data.EnergyExpanded = p3 == null ? null : (int?)p3;
            List<int> rrs = new List<int>();
            if (p4 != null)
            {
                foreach (var rr in p4)
                {
                    rrs.Add((int)rr);
                }
            }
            data.RrIntervals = rrs;
            Callback?.OnHeartRateMeasurementReceived(data);
        }

        public void OnModelName(BluetoothDevice p0, string p1)
        {
            //Callback?.OnModelName(p1);
        }

        public void OnRssiRead(BluetoothDevice p0, int p1)
        {
            //Callback?.OnRssiRead(p1);
        }

        public void OnSerialNumber(BluetoothDevice p0, string p1)
        {
            //Callback?.OnSerialNumber(p1);
        }

        public void OnSoftwareVersion(BluetoothDevice p0, string p1)
        {
            //Callback?.OnSoftwareVersion(p1);
        }

        public void OnSportReceived(BluetoothDevice p0, int p1, int p2, int p3)
        {
            ChileafSportData data = new ChileafSportData(p1,p2,p3);
            Callback?.OnSportReceived(data);
        }

        public void OnSystemId(BluetoothDevice p0, string p1)
        {
            //Callback?.OnSystemId(p1);
        }

        public void OnVendorName(BluetoothDevice p0, string p1)
        {
            //Callback?.OnVendorName(p1);
        }
    }
}
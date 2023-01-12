using ChileafBleXamarin.DataTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChileafBleXamarin.Interfaces
{
    public interface IApiCallback
    {
        void OnBatteryLevelChanged(int level);
        void OnDeviceConnected();
        void OnDeviceConnecting();
        void OnDeviceDisconnected();
        void OnDeviceDisconnecting();
        void OnHeartRateMeasurementReceived(ChileafHrData data);
        void OnBodySensorLocationReceived(int location);
        void OnSportReceived(ChileafSportData data);

        ////device info callbacks
        //void OnFirmwareVersion(string version);
        //void OnHardwareVersion(string version);
        //void OnModelName(string modelName);
        //void OnRssiRead(int rrsi);
        //void OnSerialNumber(string serialNumber);
        //void OnSoftwareVersion(string version);
        //void OnSystemId(string systemId);
        //void OnVendorName(string vendorName);
    }
}

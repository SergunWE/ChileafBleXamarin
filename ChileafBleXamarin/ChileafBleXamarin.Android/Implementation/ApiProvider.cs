using ChileafBleXamarin.Droid.Chileaf;
using ChileafBleXamarin.Interfaces;
using Com.Android.Chileaf.Wear;
using System.Collections.Generic;
using System;
using Xamarin.Forms;
using static Android.Bluetooth.BluetoothClass;
using System.Threading.Tasks;
using ChileafBleXamarin.DataTypes;
using Android.Content;

[assembly: Dependency(typeof(ChileafBleXamarin.Droid.Implementation.ApiProvider))]
namespace ChileafBleXamarin.Droid.Implementation
{
    internal class ApiProvider : IApiProvider
    {
        private static WearManager _wearManager;
        private readonly ChileafApiCallback _chileafApiCallback;
        private bool _searchRunning;

        public ApiProvider()
        {
            _wearManager = WearManager.GetInstance(ChileafSDK.Context);
            _chileafApiCallback = new ChileafApiCallback();
        }

        public void Connect(IBTDevice device)
        {
            _wearManager.Connect((Android.Bluetooth.BluetoothDevice)device.Native, true);
        }

        public void Disconnect()
        {
            _wearManager.DisConnect();
        }

        public ChileafDeviceInfo GetDeviceInfo()
        {
            if(_wearManager.IsConnected)
            {
                _wearManager.ReadProfileCharacteristic();
                ChileafDeviceInfo info = new ChileafDeviceInfo();
                info.Rssi = (int)_wearManager.Rssi;
                info.SoftwareVersion = _wearManager.SoftwareVersion;
                info.FirmwareVersion = _wearManager.FirmwareVersion;
                info.HardwareVersion = _wearManager.HardwareVersion;
                info.SerialNumber = _wearManager.SerialNumber;
                info.BatteryLevel = (int)_wearManager.BatteryLevel;
                info.ModelName = _wearManager.ModelName;
                info.SystemId = _wearManager.SystemId;
                info.VendorName = _wearManager.VendorName;
                return info;
            }
            return new ChileafDeviceInfo();
        }

        public void SetApiCallback(IApiCallback callback)
        {
            _chileafApiCallback.Callback = callback;
        }

        public void SetDebug(bool debug)
        {
            _wearManager.SetDebug(debug);
        }

        public async void StartSearch(Action<List<IBTDevice>> deviceList, TimeSpan searchTime)
        {
            if (_searchRunning) throw new Exception("Search already running");
            _searchRunning = true;
            CustomScanCallback callback = new CustomScanCallback();
            _wearManager.StartScan(callback);
            await Task.Delay(searchTime);
            StopSearch();
            deviceList?.Invoke(callback.FoundedDevices);
        }

        public void StopSearch()
        {
            _wearManager.StopScan();
            _searchRunning = false;
        }
    }
}
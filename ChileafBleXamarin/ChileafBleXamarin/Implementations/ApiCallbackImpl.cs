using ChileafBleXamarin.DataTypes;
using ChileafBleXamarin.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChileafBleXamarin.Implementations
{
    public class ApiCallbackImpl : IApiCallback
    {
        public Action<int> BatteryAction { get; set; }
        public Action<bool> ConnectedAction { get; set; }
        public Action<ChileafHrData> HeartRateDataAction { get; set; }
        public Action<ChileafSportData> SportDataAction { get; set; }
        public Action<int> SensorLocationAction { get; set; }

        public void OnBatteryLevelChanged(int level)
        {
            BatteryAction?.Invoke(level);
        }

        public void OnBodySensorLocationReceived(int location)
        {
            SensorLocationAction?.Invoke(location);
        }

        public void OnDeviceConnected()
        {
            ConnectedAction?.Invoke(true);
        }

        public void OnDeviceConnecting()
        {
            
        }

        public void OnDeviceDisconnected()
        {
            ConnectedAction?.Invoke(false);
        }

        public void OnDeviceDisconnecting()
        {
            
        }

        public void OnHeartRateMeasurementReceived(ChileafHrData data)
        {
            HeartRateDataAction?.Invoke(data);
        }

        public void OnSportReceived(ChileafSportData data)
        {
            SportDataAction?.Invoke(data);
        }
    }
}

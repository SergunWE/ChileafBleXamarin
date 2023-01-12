using ChileafBleXamarin.DataTypes;
using ChileafBleXamarin.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChileafBleXamarin.Implementations
{
    public class ApiCallbackImpl : IApiCallback
    {
        Action<int> BatteryAction { get; set; }
        Action<bool> ConnectedAction { get; set; }
        Action<ChileafHrData> HeartRateDataAction { get; set; }
        Action<ChileafSportData> SportDataAction { get; set; }
        Action<int> SensorLocationAction { get; set; }

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

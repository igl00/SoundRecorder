using System.Data;
using CSCore.CoreAudioAPI;


namespace SoundRecorder
{
    public class CaptureDevice
    {
        public DataFlow CaptureMode { get; private set; }
        public MMDevice Device { get; private set; }

        public CaptureDevice(string captureDeviceGUID)
        {
            SetCaptureDevice(captureDeviceGUID);
            if (this.Device == null)
            {
                throw new NoNullAllowedException("Please provide a valid capture device.");
            }
        }

        /// <summary>
        /// Sets the capture device to record from based on the provided deviceGUID
        /// </summary>
        /// <param name="deviceGUID"></param>
        private void SetCaptureDevice(string deviceGUID)
        {
            using (var deviceRenderEnumerator = new MMDeviceEnumerator())
            using (var Devices = deviceRenderEnumerator.EnumAudioEndpoints(DataFlow.All, DeviceState.Active))
            {
                foreach (var device in Devices)
                {
                    if (device.DeviceID == deviceGUID)
                    {
                        Device = device;
                        CaptureMode = device.DataFlow;
                        return;
                    }
                }
                this.Device = null;
            }
        }
    }
}

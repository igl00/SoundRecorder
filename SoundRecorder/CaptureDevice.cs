using System.Data;
using CSCore.CoreAudioAPI;


namespace SoundRecorder
{
    class CaptureDevice
    {
        public CaptureModeOptions CaptureMode { get; private set; }
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
            using (var inputRenderDevices = deviceRenderEnumerator.EnumAudioEndpoints(DataFlow.Render, DeviceState.Active))
            using (var inputCaptureDevices = deviceRenderEnumerator.EnumAudioEndpoints(DataFlow.Capture, DeviceState.Active))
            {
                foreach (var device in inputRenderDevices)
                {
                    if (device.DeviceID == deviceGUID)
                    {
                        Device = device;
                        CaptureMode = CaptureModeOptions.LoopbackCapture;
                        return;
                    }
                }

                foreach (var device in inputCaptureDevices)
                {
                    if (device.DeviceID == deviceGUID)
                    {
                        Device = device;
                        CaptureMode = CaptureModeOptions.Capture;
                        return;
                    }
                }
                this.Device = null;
            }
        }
    }
}

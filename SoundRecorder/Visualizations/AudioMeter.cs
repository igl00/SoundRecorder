using System;
using CSCore.CoreAudioAPI;
using CSCore.SoundIn;

namespace SoundRecorder.Visualizations
{
    public class AudioMeter : IDisposable
    {
        private AudioMeterInformation _audioMeterInformation;
        private MMDevice _endpoint;
        private WasapiCapture _dummyCapture;

        public MMDevice Endpoint
        {
            get { return _endpoint; }
            set
            {
                _endpoint = value;
                EnableCaptureEndpoint();

                if (_endpoint != null)
                {
                    _audioMeterInformation = AudioMeterInformation.FromDevice(_endpoint);
                }
            }
        }

        public float[] GetChannelsPeakValues()
        {
            return _audioMeterInformation.GetChannelsPeakValues();
        }

        public static AudioMeter FromDevice(MMDevice Device)
        {
            AudioMeter audioMeter = new AudioMeter();
            audioMeter.Endpoint = Device;
            return audioMeter;
        }

        private void EnableCaptureEndpoint()
        {
            if (_dummyCapture != null)
            {
                _dummyCapture.Dispose();
                _dummyCapture = null;
            }

            if (Endpoint != null && Endpoint.DataFlow == DataFlow.Capture)
            {
                _dummyCapture = new WasapiCapture(true, AudioClientShareMode.Shared, 250) {Device = Endpoint};
                _dummyCapture.Initialize();
                _dummyCapture.Start();
            }
        }

        public void Dispose()
        {
            if (_dummyCapture != null)
            {
                _dummyCapture.Dispose();
                _dummyCapture = null;
            }
        }
    }
}
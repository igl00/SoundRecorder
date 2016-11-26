using System;
using CSCore;
using CSCore.Codecs.WAV;
using CSCore.CoreAudioAPI;
using CSCore.MediaFoundation;
using CSCore.SoundIn;
using CSCore.Streams;


namespace SoundRecorder
{
    class Recorder
    {
        private readonly SoundInSource _soundInSource;
        private readonly IWaveSource _waveStream;
        private IWriteable _writer;
        private RecordingState _state = RecordingState.Stopped;

        public SingleBlockNotificationStream NotificationStream;

        public Recorder(MMDevice captureDevice, CaptureModeOptions captureMode)
        {
            var wasapiCapture = Convert.ToBoolean(captureMode) ? new WasapiLoopbackCapture() : new WasapiCapture();

            wasapiCapture.Device = captureDevice;
            wasapiCapture.Initialize();

            _soundInSource = new SoundInSource(wasapiCapture);
            NotificationStream = new SingleBlockNotificationStream(_soundInSource.ToSampleSource());
            _waveStream = NotificationStream.ToWaveSource();
        }

        /// <summary>
        /// Create a new file based on the given filename and start recording to it.
        /// Filename must include its full path.
        /// </summary>
        /// <param name="fileName">The name of a file to be created. Include its full path</param>
        /// <param name="codec">The codec to record in</param>
        /// <param name="bitRate">The bitrate of the file</param>
        /// <param name="channels">The channels to record</param>
        public void StartCapture(string fileName, AvailableCodecs codec, int bitRate, Channels channels)
        {
            if (!ReadyToRecord())
            {
                throw new NullReferenceException("There is no SoundInSource configured for the recorder.");
            }

            fileName = $"{fileName}.{codec.ToString().ToLower()}";

            WaveFormat waveSource;
            switch (channels)
            {
                case Channels.Mono:
                    waveSource = _soundInSource.ToMono().WaveFormat;
                    break;
                case Channels.Stereo:
                    waveSource = _soundInSource.ToStereo().WaveFormat;
                    break;
                default:
                    throw new ArgumentException("The selected channel option could not be found.");
            }

            switch (codec)
            {
                case AvailableCodecs.MP3:
                    _writer = MediaFoundationEncoder.CreateMP3Encoder(waveSource, fileName, bitRate);
                    break;
                case AvailableCodecs.AAC:
                    _writer = MediaFoundationEncoder.CreateAACEncoder(waveSource, fileName, bitRate);
                    break;
                case AvailableCodecs.WMA:
                    _writer = MediaFoundationEncoder.CreateWMAEncoder(waveSource, fileName, bitRate);
                    break;
                case AvailableCodecs.WAV:
                    _writer = new WaveWriter(fileName, waveSource);
                    break;
                default:
                    throw new ArgumentException("The specified codec was not found.");
            }

//            byte[] buffer = new byte[_waveStream.WaveFormat.BytesPerSecond / 2]; // TODO: Take into account the channels
//
//            _soundInSource.DataAvailable += (s, e) =>
//            {
//                int read;
//                while ((read = _waveStream.Read(buffer, 0, buffer.Length)) > 0)
//                {
//                    _writer.Write(buffer, 0, read);
//                }
//            };

            byte[] buffer = new byte[_waveStream.WaveFormat.BytesPerSecond];

            _soundInSource.DataAvailable += (s, e) =>
            {
                int read = _waveStream.Read(buffer, 0, buffer.Length);
                _writer.Write(buffer, 0, read);
            };

            // Start recording
            _soundInSource.SoundIn.Start();
            _state = RecordingState.Recording;
        }

        /// <summary>
        /// Stop the recording and reset the recorder for a new recording.
        /// </summary>
        public void StopCapture()
        {
            if (_soundInSource?.SoundIn != null)
            {
                _soundInSource.SoundIn.Stop();
                // Clean up the file writer
                ((IDisposable)_writer)?.Dispose();
                _state = RecordingState.Stopped;
            }
        }

        /// <summary>
        /// Pause the recording.
        /// </summary>
        public void PauseCapture()
        {
            _soundInSource.SoundIn.Stop();
            _state = RecordingState.Paused;
        }

        /// <summary>
        /// Resume a paused recording.
        /// </summary>
        public void ResumePausedCapture()
        {
            _soundInSource.SoundIn.Start();
            _state = RecordingState.Recording;
        }

        /// <summary>
        /// Returns true if the recorder is currently recording
        /// </summary>
        /// <returns></returns>
        public bool Recording()
        {
            return _state == RecordingState.Recording;
        }

        /// <summary>
        /// Returns true if the recorder is currently paused
        /// </summary>
        /// <returns></returns>
        public bool Paused()
        {
            return _state == RecordingState.Paused;
        }

        /// <summary>
        /// Returns true if the recorder is ready to start recording
        /// </summary>
        /// <returns></returns>
        public bool ReadyToRecord()
        {
            return _soundInSource != null;
        }

        /// <summary>
        /// Clean up the cscore elements
        /// </summary>
        public void Dispose()
        {
            _soundInSource.SoundIn.Dispose();
        }
    }
}

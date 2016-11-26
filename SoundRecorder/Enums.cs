namespace SoundRecorder
{
    public enum AvailableCodecs 
    {
        MP3,
        AAC,
        WAV,
        WMA,
    }

    public enum CaptureModeOptions
    {
        Capture,
        LoopbackCapture
    }

    public enum RecordingState
    {
        Recording,
        Stopped,
        Paused
    }

    public enum Channels
    {
        Mono,
        Stereo
    }
}

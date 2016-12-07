using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSCore.CoreAudioAPI;


namespace SoundRecorder.Test
{
    [TestClass]
    public class RecorderTest
    {
//        private CaptureDevice _captureDevice;
//        private Recorder _recorder;
//
//        [TestInitialize]
//        public void TestInitialize()
//        {
//            SelectTestDevice();
////            _captureDevice = new CaptureDevice();
////            _recorder = new Recorder();
//        }
//
//        private void SelectTestDevice()
//        {
////            using (var deviceRenderEnumerator = new MMDeviceEnumerator())
////            using (var inputRenderDevices = deviceRenderEnumerator.EnumAudioEndpoints(DataFlow.Render, DeviceState.Active))
////            using (var inputCaptureDevices = deviceRenderEnumerator.EnumAudioEndpoints(DataFlow.Capture, DeviceState.Active))
////            {
////                int count = 0;
////                IEnumerable<MMDevice> devices;
////
////                foreach (var device in inputRenderDevices)
////                {
////                    Console.WriteLine($"{count}: {device}");
////                    count++;
////                }
////
////                foreach (var device in inputCaptureDevices)
////                {
////                    Console.WriteLine($"{count}: {device}");
////                    count++;
////                }
////                Console.WriteLine("x: Quit");
////
////                char[] options = new char[count + 1];
////                for (int i = 0; i <= count; i++)
////                {
////                    options[i] = (char) i;
////                }
////                options[count + 1] = 'x';
//
////                do
////                {
////                    Console.WriteLine($"Please select an input device(0 - {count}): ");
////                } while ((char) Console.Read());
//
//            }
//        }
//
//        [TestMethod]
//        public void PausedTest()
//        {
//            
//        }
//
//        [TestMethod]
//        public void ReadyToRecordTest()
//        {
//            
//        }
    }
}

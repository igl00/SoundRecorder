using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Timers;
using SoundRecorder.Visualizations;


namespace SoundRecorder
{
    class PeakMeterDisplay : Visualization
    {
        private float _left;
        private float _right;
        private int _width;
        private int _height;

        private float _peakLeft;
        private Timer _peakLeftTimer;
        private bool _holdLeft;
        private Timer _clipLeftTimer;
        private bool _holdClipLeft;

        private float _peakRight;
        private Timer _peakRightTimer;
        private bool _holdRight;
        private Timer _clipRightTimer;
        private bool _holdClipRight;

        private float _peakDecay = 0.01f;  // Percent TODO: Make this variable name clearer
        private LinearGradientBrush _gradient;
        private LinearGradientBrush _peakGradient;
        private readonly object _lockObj = new object();

        public PeakMeterDisplay(int peakHold=1000, int clipHold = 4000)
        {
            _peakLeftTimer = new Timer(peakHold);
            _peakLeftTimer.Elapsed += (sender, e) =>
            {
                _holdLeft = false;
            };

            _peakRightTimer = new Timer(peakHold);
            _peakRightTimer.Elapsed += (sender, e) =>
            {
                _holdRight = false;
            };

            _clipLeftTimer = new Timer(clipHold);
            _clipLeftTimer.Elapsed += (sender, e) =>
            {
                _holdClipLeft = false;
            };

            _clipRightTimer = new Timer(clipHold);
            _clipRightTimer.Elapsed += (sender, e) =>
            {
                _holdClipRight = false;
            };
        }


        private LinearGradientBrush DrawGradient(int width, int height)
        {
            var sizeRectangle = new Rectangle(0, 0, width, height);
            LinearGradientBrush gradient = new LinearGradientBrush(sizeRectangle, Color.Black, Color.Black, LinearGradientMode.Horizontal);

            ColorBlend colorBlend = new ColorBlend();
            colorBlend.Positions = new[] {0f, 0.87f, 1f};
            colorBlend.Colors = new[] { ColorTranslator.FromHtml("#65a265"), ColorTranslator.FromHtml("#bad763"), ColorTranslator.FromHtml("#e65151") };

            gradient.InterpolationColors = colorBlend;

            return gradient;
        }

        private LinearGradientBrush DrawPeakGradient(int width, int height)
        {
            var sizeRectangle = new Rectangle(0, 0, width, height);
            LinearGradientBrush gradient = new LinearGradientBrush(sizeRectangle, Color.Black, Color.Black, LinearGradientMode.Horizontal);

            ColorBlend colorBlend = new ColorBlend();
            colorBlend.Positions = new[] { 0f, 0.87f, 1f };
//            colorBlend.Colors = new[] { ColorTranslator.FromHtml("#44ca44"), ColorTranslator.FromHtml("#ddfe2b"), ColorTranslator.FromHtml("#ff2828") };
            colorBlend.Colors = new[] { ColorTranslator.FromHtml("#44bf44"), ColorTranslator.FromHtml("#cfef2e"), ColorTranslator.FromHtml("#f02b2b") };

            gradient.InterpolationColors = colorBlend;

            return gradient;
        }

        public override void AddSamples(float left, float right)
        {
            lock (_lockObj)
            {
                if (left > this._left)
                    this._left = left;

                if (right > this._right)
                    this._right = right;
            }
        }

        public override Image Draw(int width, int height)
        {
            var image = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(image))
            {
                Draw(g, width, height);
            }

            this._left = 0;
            this._right = 0;

            return image;
        }

        public override void Draw(Graphics graphics, int width, int height)
        {
            // create the gradient
            if (_gradient == null || width != _width || height != _height)
            {
                _gradient = DrawGradient(width, height);
            }
            // create the peak gradient
            if (_peakGradient == null || width != _width || height != _height)
            {
                _peakGradient = DrawPeakGradient(width, height);
            }

            // peak hold
            if (_left > _peakLeft)
            {
                _peakLeft = _left;
                _holdLeft = true;
                _peakLeftTimer.Start();
            }
            else
            {
                if (_peakLeft > 0 && !_holdLeft)
                {
                    _peakLeft -= _peakDecay;
                }
            }

            if (_right > _peakRight)
            {
                _peakRight = _right;
                _holdRight = true;
                _peakRightTimer.Start();
            }
            else
            {
                if (_peakRight > 0 && !_holdRight)
                {
                    _peakRight -= _peakDecay;
                }
            }

            // Clip Light
            if (_left >= 1)
            {
                _holdClipLeft = true;
                _clipLeftTimer.Stop();  // Restarts the timer if it already running
                _clipLeftTimer.Start();
            }
            if (_right >= 1)
            {
                _holdClipRight = true;
                _clipRightTimer.Stop();
                _clipRightTimer.Start();
            }

            int clipLightWidth = 5;
            int clipLightPadding = 3;
            
            // LEFT CHANNEL

            // background
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, Color.DarkGray)), 0, 0, width - (clipLightWidth + clipLightPadding), 21);
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, ColorTranslator.FromHtml("#d6d6d6"))), width - (clipLightWidth + clipLightPadding), 0, 1, 21);
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, ColorTranslator.FromHtml("#e2e2e2"))), width - (clipLightWidth + (clipLightPadding - 1)), 0, clipLightPadding - 2, 21);
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, ColorTranslator.FromHtml("#d6d6d6"))), width - (clipLightWidth + 1), 0, 1, 21);
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, Color.DarkGray)), width - clipLightWidth, 0, clipLightWidth, 21);

            // clipping light
            if (_holdClipLeft)
            {
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, Color.Red)), width - clipLightWidth, 0, clipLightWidth, 21);
            }

            //level bar
            graphics.FillRectangle(_gradient, 0, 0, this._left * (width - (clipLightWidth + clipLightPadding)), 21);
            
            // level bar peak
            if (_peakLeft > 0)
            {
                graphics.FillRectangle(_peakGradient, this._peakLeft * (width - (clipLightWidth + clipLightPadding)) - 2, 0, 2, 21);
            }

            // RIGHT CHANNEL

            // background
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, Color.DarkGray)), 0, 23, width - (clipLightWidth + clipLightPadding), 21);
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, ColorTranslator.FromHtml("#d6d6d6"))), width - (clipLightWidth + clipLightPadding), 23, 1, 21);
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, ColorTranslator.FromHtml("#e2e2e2"))), width - (clipLightWidth + (clipLightPadding - 1)), 23, clipLightPadding - 2, 21);
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, ColorTranslator.FromHtml("#d6d6d6"))), width - (clipLightWidth + 1), 23, 1, 21);
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, Color.DarkGray)), width - clipLightWidth, 23, clipLightWidth, 21);

            // clipping light
            if (_holdClipRight)
            {
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, Color.Red)), width - clipLightWidth, 23, clipLightWidth, 21);
            }

            // level bar
            graphics.FillRectangle(_gradient, 0, 23, this._right * (width - (clipLightWidth + clipLightPadding)), 21);
            
            // level bar peak
            if (_peakRight > 0)
            {
                graphics.FillRectangle(_peakGradient, this._peakRight * (width - (clipLightWidth + clipLightPadding)) - 2, 23, 2, 21);
            }
        }
    }
}

using System.Drawing;
using System.Drawing.Drawing2D;
using SoundRecorder.Visualizations;


namespace SoundRecorder
{
    class PeakMeterDisplay : Visualization
    {
        private float _left;
        private float _peakLeft;
        private float _right;
        private float _peakRight;

        private int _width;
        private int _height;
        private int _peakHold;  // TODO: This isn't in a unit of time
        private int _peakDecay;  // Milliseconds TODO: Make this variable name clearer

        // TODO: Non-linear peak decay

        private LinearGradientBrush _gradient;

        private readonly object _lockObj = new object();

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
            // peak hold
            if (_left > _peakLeft) _peakLeft = _left;
            else _peakLeft -= _peakDecay;
            if (_right > _peakRight) _peakRight = _right;
            else _peakRight -= _peakDecay;

            // left channel:
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, Color.DarkGray)), 0, 0, width, 21);
            graphics.FillRectangle(_gradient, 0, 0, this._left * width, 21);  // new SolidBrush(Color.FromArgb(150, Color.Red))

            // right channel:
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, Color.DarkGray)), 0, 23, width, 21);
            graphics.FillRectangle(_gradient, 0, 23, this._right * width, 21);  // new SolidBrush(Color.FromArgb(150, Color.ForestGreen))
        }
    }
}

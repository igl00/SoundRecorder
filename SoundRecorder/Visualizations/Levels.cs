using System.Drawing;

using SoundRecorder.Visualizations;


namespace SoundRecorder
{
    class Levels : Visualization
    {
        private float _left;
        private float _right;

        private readonly object _lockObj = new object();
        
        override public void AddSamples(float left, float right)
        {
            lock (_lockObj)
            {
                if (left > this._left)
                    this._left = left;

                if (right > this._right)
                    this._right = right;
            }
        }

        override public Image Draw(int width, int height)
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

        override public void Draw(Graphics graphics, int width, int height)
        {
            //left channel:
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, Color.DarkGray)), 0, 0, width, 21);
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, Color.Red)), 0, 0, this._left * width, 21);
            //right channel:
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, Color.DarkGray)), 0, 23, width, 21);
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, Color.ForestGreen)), 0, 23, this._right * width, 21);
        }
    }
}

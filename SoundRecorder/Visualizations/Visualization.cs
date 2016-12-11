using System;
using System.Drawing;


namespace SoundRecorder.Visualizations
{
    abstract class Visualization
    {
        abstract public Image Draw(int width, int height);
        abstract public void Draw(Graphics graphics, int width, int height);
        abstract public void AddSamples(float left, float right);
    }
}

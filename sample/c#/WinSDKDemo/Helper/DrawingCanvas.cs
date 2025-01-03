using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace WinSDKDemo.Helper
{
    public class DrawingCanvas : IDisposable
    {
        private Bitmap _bitmap;
        private Graphics _graphics;

        public DrawingCanvas(int width, int height)
        {
            _bitmap = new Bitmap(width, height);
            _graphics = Graphics.FromImage(_bitmap);
            _graphics.Clear(Color.White); // Set background to white
        }

        public void DrawText(string text, Font font, Brush brush, PointF position)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            if (font == null) throw new ArgumentNullException(nameof(font));
            if (brush == null) throw new ArgumentNullException(nameof(brush));

            _graphics.DrawString(text, font, brush, position);
        }

        public void DrawLine(Pen pen, Point startPoint, Point endPoint)
        {
            if (pen == null) throw new ArgumentNullException(nameof(pen));

            _graphics.DrawLine(pen, startPoint, endPoint);
        }

        public void DrawRectangle(Pen pen, Rectangle rect)
        {
            if (pen == null) throw new ArgumentNullException(nameof(pen));

            _graphics.DrawRectangle(pen, rect);
        }

        public void SaveToFile(string filePath, ImageFormat format)
        {
            if (format == null) throw new ArgumentNullException(nameof(format));

            _bitmap.Save(filePath, format);
        }

        public virtual void Dispose()
        {
            _graphics?.Dispose();
            _bitmap?.Dispose();
        }
    }
}

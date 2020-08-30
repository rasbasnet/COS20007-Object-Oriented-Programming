using System;
using System.IO;
using SplashKitSDK;
namespace ShapeDrawer
{
    public class MyRectangle : Shape
    {
        private int _width, _height;

        public MyRectangle(Color clr, float x, float y, int width, int height): base (clr)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }
        public MyRectangle() : this(Color.Green, 0, 0, 100, 100)
        {

        }

        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }

        public override void Draw()
        {
            if (Selected)
            {
                this.DrawOutline();
            }
            SplashKit.FillRectangle(this.Color, this.X, this.Y, this.Width, this.Height);
        }

        public override void DrawOutline()
        {
            SplashKit.FillRectangle(Color.Black, this.X - 2, this.Y - 2, this.Width + 4, this.Height + 4);
        }
        public override bool IsAt(Point2D point)
        {
            return SplashKit.PointInRectangle(point, SplashKit.RectangleFrom(this.X, this.Y, this.Width, this.Height));
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Rectangle");
            base.SaveTo(writer);
            writer.WriteLine(_width);
            writer.WriteLine(_height);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _width = reader.ReadInteger();
            _height = reader.ReadInteger();
        }
    }
}

using System;
using System.IO;
using SplashKitSDK;
namespace ShapeDrawer
{
    public class MyCircle : Shape
    {
        private int _radius;

        public MyCircle(Color color, int radius) : base(color)
        {
            _radius = radius;
        }
        public MyCircle() : this(Color.Blue, 50)
        {

        }

        public override void Draw()
        {
            if (Selected)
            {
                this.DrawOutline();
            }
            SplashKit.FillCircle(this.Color, this.X, this.Y, _radius);
        }
        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, this.X - 2, this.Y - 2, _radius + 2);
        }

        public override bool IsAt(Point2D point)
        {
            return SplashKit.PointInCircle(point, SplashKit.CircleAt(this.X, this.Y, _radius));
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Circle");
            base.SaveTo(writer);
            writer.WriteLine(_radius);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Radius = reader.ReadInteger();
        }

        public int Radius { get => _radius; set => _radius = value; }


    }
}

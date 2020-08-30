using System;
using System.IO;
using SplashKitSDK;
namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private int _radius;

        public MyLine(Color clr) : base(clr)
        {
            _radius = 10;
        }
        public MyLine() : this(Color.OrangeRed)
        {

        }

        public override void Draw()
        {
            if (this.Selected)
            {
                this.DrawOutline();
            }
            SplashKit.DrawLine(this.Color, SplashKit.LineFrom(SplashKit.PointAt(this.X-100, this.Y), SplashKit.PointAt(this.X + 100, this.Y)));
        }

        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, this.X-100, this.Y, _radius);
            SplashKit.FillCircle(Color.Black, this.X + 100, this.Y, _radius);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
        }

        public override bool IsAt(Point2D point)
        {
            return SplashKit.PointOnLine(point, SplashKit.LineFrom(SplashKit.PointAt(this.X-100, this.Y), SplashKit.PointAt(this.X + 100, this.Y)));
        }
    }
}

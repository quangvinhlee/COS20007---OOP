using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
namespace ShapeDrawer
{
    public class MyCircle : Shape
    {
        private int _radius;

        public MyCircle(Color clr,float x, float y, int radius) : base(clr)
        {
           
            _radius = radius;
        }
        public MyCircle() : this(Color.Blue,0,0, 50) { }
        public int Radius { get { return _radius; } set { value = _radius; } }
        public override void Draw()
        {
            if (Selected)
                DrawOutline();
            SplashKit.FillCircle(Color, X, Y, _radius);
        }
        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color, X - 2, Y - 2, _radius + 2);
        }
        public override bool IsAt(Point2D p)
        {
            double a = (double)(p.X - X);
            double b = (double)(p.Y - Y);
            if (Math.Sqrt(a * a + b * b) < _radius)
            {
                return true;
            }
            return false;
        }
        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Circle");
            base.SaveTo(writer);
            writer.WriteLine(Radius);
        }
        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader); // This reads Color, X, and Y
            Radius = reader.ReadInteger();
        }
    }
}

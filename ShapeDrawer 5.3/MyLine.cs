using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private int _length;

        public MyLine(Color clr, int lenght) : base(clr)
        {
            _length = lenght;
        }
        public MyLine() : this(Color.RandomRGB(255), 100) { }

        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }

        public override void Draw()
        {
            if (Selected) 
            {
                DrawOutline();
            }
            SplashKit.DrawLine(Color, X, Y, X + _length + 3, Y);
        }
        public override void DrawOutline()
        {
            SplashKit.DrawLine(Color, X + 1, Y + 1 , _length + 5, Y);
        }
        public override bool IsAt(Point2D p)
        {
            return SplashKit.PointOnLine(p, SplashKit.LineFrom(X, Y, X + _length, Y));
        }
        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(Length);
        }
        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Length = reader.ReadInteger();
        }
    }
}

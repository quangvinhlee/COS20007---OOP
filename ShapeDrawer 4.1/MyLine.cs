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
        private float _endX;
        private float _endY;
        public MyLine(Color clr,float startX, float startY, float endX, float endY) : base(clr)
        {
            _endX = endX;
            _endY = endY;
            X = startX;
            Y = startY;

        }
        public MyLine() : this(Color.RandomRGB(255), 10, 10, 10, 10) { }

        public float EndX
        {
            get { return _endX; }
            set { _endX = value; }
        }
        public float EndY
        {
            get { return _endY; }
            set { _endY = value; }
        }

        public override void Draw()
        {
            if (Selected) 
            {
                DrawOutline();
            }
            SplashKit.DrawLine(Color, X, Y, _endX, _endY);
        }
        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.Black, X, Y, 5);
            SplashKit.DrawCircle(Color.Black, _endX, _endY, 5);
        }
        public override bool IsAt(Point2D p)
        {
            /*double x = p.X;
            double y = p.Y;

            return true;*/
            if (p.X <= X && p.Y <= Y)
            {
                return SplashKit.PointOnLine(p, SplashKit.LineFrom(X, Y, EndX, EndY));

            }
            return false;
        }
    }
}

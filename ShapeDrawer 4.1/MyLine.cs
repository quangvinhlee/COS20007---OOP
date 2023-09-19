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
        public MyLine() : this(Color.RandomRGB(255), 0, 0, 20, 20) { }

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
            // Calculate the distance from the point to the line
            double distance = Math.Abs((EndY - Y) * p.X - (EndX - X) * p.Y + EndX * Y - EndY * X)
                            / Math.Sqrt(Math.Pow(EndY - Y, 2) + Math.Pow(EndX - X, 2));

            // Define a tolerance value for how close the point can be to the line
            double tolerance = 5.0; // Adjust as needed

            // Check if the distance is within the tolerance
            return distance <= tolerance;
        }

    }
}

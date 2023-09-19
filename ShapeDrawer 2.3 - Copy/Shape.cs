using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public abstract class Shape
    {
        private Color _color;
        private float _x, _y;
       
        private bool _selected;

        public Shape(Color color)
        {
            _color = color;
            _x = SplashKit.MouseX(); 
            _y = SplashKit.MouseY(); 
            
        }
        public Shape() : this(Color.Yellow)
        {
        }
        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public virtual void Draw()
        {
            
        }

        public virtual bool IsAt(Point2D p)
        {
            return false;
        }

        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
            }
        }

        public virtual void DrawOutline()
        {
        }
    }
}

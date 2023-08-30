using System;
using System.Linq;
using System.Collections.Generic;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;

        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }

        public Drawing() : this(Color.White)
        {
        }

        public List<Shape> SelectedShapes()
        {
            List<Shape> _selectedShapes = new List<Shape>();
            foreach (Shape s in _selectedShapes)
            {
                if (s.Selected)
                {
                    _selectedShapes.Add(s);
                }
            }
            return _selectedShapes;
        }

        public int ShapeCount
        {
            get
            {
                return _shapes.Count;
            }
        }

        public Color Background
        {
            get
            {
                return _background;
            }
            set
            {
                _background = value;
            }
        }

        public void Draw()
        {
            SplashKit.ClearScreen(_background);

            foreach (Shape s in _shapes)
            {
                s.Draw();
            }
        }

        public void SelectedShapeAt(Point2D pt)
        {
            foreach (Shape s in _shapes)
            {
                if (s.IsAt(pt))
                {
                    s.Selected = true;
                }
                else
                {
                    s.Selected = false;
                }
            }
        }

        public void AddShape(Shape s)
        {
            _shapes.Add(s);
        }

        public void RemoveShape()
        {
            foreach (Shape s in _shapes.ToList())
            {
                if (s.Selected)
                {
                    _shapes.Remove(s);
                }
            }
        }
        public void Save(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);

            writer.WriteColor(Background);
            writer.WriteLine(ShapeCount);
            foreach(Shape s in _shapes)
            {
                s.SaveTo(writer);
            }
            writer.Close();
        }
        public void Load (string filename)
        {
            StreamReader reader = new StreamReader(filename);
            Background = reader.ReadColor();
            int count = reader.ReadInteger();
            _shapes.Clear();
            for (int i = 0; i < count; i++)
            {
                string kind = reader.ReadLine();
                Shape s;
                if (kind == "Rectangle")
                {
                    s = new MyRectangle();
                } else if (kind == "Circle")
                {
                    s = new MyCircle();
                }else
                {
                    continue;
                }
                s.LoadFrom(reader);
                _shapes.Add(s);

            }
            reader.Close();

        }

    }
}

using System;
using System.IO;
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
        //this is called when object is created which then calls upper constructor
        public Drawing() : this(Color.White)
        {

        }

        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach (Shape shape in _shapes)
            {
                shape.Draw();
            }
        }

        public int ShapeCount
        {
            get
            {
                return _shapes.Count;

            }
        }

        public void AddShapes(Shape shape)
        {
            _shapes.Add(shape);
        }

        public void SelectShapesAt(Point2D pt)
        {
            foreach (Shape s in _shapes)
            {
                /*
                 * 
                 * 1) If object is selected and mouse is over it then it will be unselected (false && true == false)
                 * 2) In case that mouse over objects will be selected ( true && (true || x) == true)
                 *    Other selected objects will still remain selected (true && (false || true) == true)
                 * 3) Both cannot be false (false && false)
                 * 
                 */

                s.Selected = !(s.IsAt(pt) && s.Selected) & (s.IsAt(pt) || s.Selected);
            }
        }

        // returns a list of shapes that have been selected
        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result = new List<Shape>();
                foreach (Shape s in _shapes)
                {
                    if (s.Selected)
                    {
                        result.Add(s);
                    }
                }
                return result;
            }

        }
        
        public void RemoveShape(Shape shape)
        {
            _shapes.Remove(shape);
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

        public void Save(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);
            try
            {
                writer.WriteColor(_background);
                writer.WriteLine(ShapeCount);

                foreach (Shape s in _shapes)
                {
                    s.SaveTo(writer);
                }
            } finally
            {
                writer.Close();

            }
        }

        public void Load(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            try
            {
                Shape s;
                int count;
                string kind;

                this.Background = reader.ReadColor();
                count = reader.ReadInteger();

                _shapes.Clear();

                for (int i = 0; i < count; i++)
                {
                    kind = reader.ReadLine();
                    s = Shape.CreateShape(kind);

                    s.LoadFrom(reader);
                    this.AddShapes(s);

                }
            } finally
            {
                reader.Close();
            }

        }


    }
}

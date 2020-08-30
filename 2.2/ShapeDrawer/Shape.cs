using System;
using System.Collections.Generic;
using System.IO;
using SplashKitSDK;
namespace ShapeDrawer
{
    public abstract class Shape
    {

        private static Dictionary<string, Type> _ShapeClassRegistry = new Dictionary<string, Type>();


        public static void RegisterShape(string name, Type t)
        {
            _ShapeClassRegistry[name] = t;
        }

        public static string GetKey(Type kind)
        {
            foreach (string key in _ShapeClassRegistry.Keys)
            {
                if (_ShapeClassRegistry[key] == kind)
                {
                    return key;
                }
            }
            return null;
        }



        public static Shape CreateShape(string name)
        {
            return (Shape)Activator.CreateInstance(_ShapeClassRegistry[name]);
        }


        private Color _color;
        private float _x, _y;
        private bool _selected;

        //Constructor
        public Shape(Color color)
        {
            _x = 0;
            _y = 0;
            _color = color;
        }

        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteLine(GetKey(this.GetType()));
            writer.WriteColor(_color);
            writer.WriteLine(_x);
            writer.WriteLine(_y);

        }

        public virtual void LoadFrom(StreamReader reader)
        {
            Color = reader.ReadColor();
            X = reader.ReadInteger();
            Y = reader.ReadInteger();
        }

        public abstract void Draw();

        public abstract void DrawOutline();

        public abstract bool IsAt(Point2D point);

        //getters and setters for the variables
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

    }
}

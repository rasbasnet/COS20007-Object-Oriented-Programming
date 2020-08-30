using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }

        public static void Main()
        {
            Shape.RegisterShape("Rectangle", typeof(MyRectangle));
            Shape.RegisterShape("Circle", typeof(MyCircle));
            Shape.RegisterShape("Line", typeof(MyLine));

            new Window("Shape Drawer", 800, 600);

            ShapeKind kindToAdd = ShapeKind.Circle;

            Drawing drawing = new Drawing();

            do
            {
                SplashKit.ProcessEvents();

                if (SplashKit.KeyDown(KeyCode.SpaceKey))
                {
                    drawing.Background = Color.RandomRGB(10);
                }

                SplashKit.RefreshScreen(60);

                if (SplashKit.KeyDown(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                if (SplashKit.KeyDown(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }
                if (SplashKit.KeyDown(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                // Draws a shape at mouse
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;
                    if (kindToAdd == ShapeKind.Circle)
                    {
                        newShape = Shape.CreateShape("Circle");
                    } else if (kindToAdd == ShapeKind.Rectangle)
                    {
                        newShape = Shape.CreateShape("Rectangle");
                    }
                    else
                    {
                        newShape = Shape.CreateShape("Line");
                    }
                    newShape.X = SplashKit.MouseX();
                    newShape.Y = SplashKit.MouseY();

                    drawing.AddShapes(newShape);
                }

                if (SplashKit.KeyDown(KeyCode.DeleteKey) || SplashKit.KeyDown(KeyCode.BackspaceKey)) {
                    foreach (Shape shape in drawing.SelectedShapes)
                    {
                        if (shape.Selected)
                        {
                            drawing.RemoveShape(shape);
                        }
                    }
                }

                if (SplashKit.KeyDown(KeyCode.OKey))
                {
                    try
                    {
                        drawing.Load("/Users/razbasnet/Desktop/TestDrawing.txt");
                    } catch (Exception e)
                    {
                        Console.Error.WriteLine($"Error loading file: {e.Message}");
                    }
                }

                if (SplashKit.KeyDown(KeyCode.SKey))
                {
                    drawing.Save("/Users/razbasnet/Desktop/TestDrawing.txt");
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    drawing.SelectShapesAt(SplashKit.MousePosition());
                }
                drawing.Draw();

            } while (!SplashKit.WindowCloseRequested("Shape Drawer"));
        }
    }
}
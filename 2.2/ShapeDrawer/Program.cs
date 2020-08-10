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
            new Window("Shape Drawer", 800, 600);

            //to start off shape is circle
            ShapeKind kindToAdd = ShapeKind.Circle;

            //creation of the drawing shape
            Drawing drawing = new Drawing();

            do
            {
                //Checks for keyboard clicks etc and sees if any new user interactions
                SplashKit.ProcessEvents();

                //If space is pressed changes drawing shapes background which is drawn when called later
                if (SplashKit.KeyDown(KeyCode.SpaceKey))
                {
                    drawing.Background = Color.RandomRGB(10);
                }

                /* Refreshes all open windows with a target FPS (frames per second).
                This will delay a period of time that will approximately meet the targeted frames per second.*/
                SplashKit.RefreshScreen(60);

                //If user presses R key, change kindToAdd to Rectangle
                if (SplashKit.KeyDown(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                //If user presses C key, change kindToAdd to Rectangle
                if (SplashKit.KeyDown(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }
                //If user presses L key, change kindToAdd to Rectangle
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
                        newShape = new MyCircle();
                    } else if (kindToAdd == ShapeKind.Rectangle)
                    {
                        newShape = new MyRectangle();
                    } else
                    {
                        newShape = new MyLine();
                    }
                    newShape.X = SplashKit.MouseX();
                    newShape.Y = SplashKit.MouseY();

                    drawing.AddShapes(newShape);
                }

                // if delete key or back is pressed then it deletes all the selected shapes
                if (SplashKit.KeyDown(KeyCode.DeleteKey) || SplashKit.KeyDown(KeyCode.BackspaceKey)) {
                    foreach (Shape shape in drawing.SelectedShapes)
                    {
                        if (shape.Selected)
                        {
                            drawing.RemoveShape(shape);
                        }
                    }
                }
                // if right clicked on a shape then it is deemed as "selected"
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    drawing.SelectShapesAt(SplashKit.MousePosition());
                }
                drawing.Draw();
            } while (!SplashKit.WindowCloseRequested("Shape Drawer"));
            //ensures at least 1 iteration, meaning shape will already be drawn when window opens
        }
    }
}
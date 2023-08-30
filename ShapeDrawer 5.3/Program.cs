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
            Drawing myDrawing = new Drawing();
            ShapeKind kindToAdd = ShapeKind.Circle;

            new Window("Drawing Shape", 800, 600);
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }
                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;
                    if (kindToAdd == ShapeKind.Circle)
                    {
                        MyCircle newCircle = new MyCircle();
                        newCircle.X = SplashKit.MouseX();
                        newCircle.Y = SplashKit.MouseY();
                        newShape = newCircle;

                    }
                    else if (kindToAdd == ShapeKind.Rectangle)
                    {
                        MyRectangle newRect = new MyRectangle();
                        newRect.X = SplashKit.MouseX();
                        newRect.Y = SplashKit.MouseY();
                        newShape = newRect;
                    }
                    else
                    {
                        MyLine newLine = new MyLine();
                        newLine.X = SplashKit.MouseX();
                        newLine.Y = SplashKit.MouseY();
                        newShape = newLine;
                    }
                    myDrawing.AddShape(newShape);
                }
                if (SplashKit.KeyTyped(KeyCode.SKey))
                {
                    string folder = "C:/Users/lequa/OneDrive/Documents/COS20007/ShapeDrawer 5.3/TestDrawing.txt";
                    try
                    {
                        myDrawing.Save(folder);
                        Console.WriteLine($"Drawing saved {folder}");
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine("Error saviing file: {0}", e.Message);
                    }
                    /* string saveFolderPath = @"C:\Users\lequa\OneDrive\Documents\COS20007\ShapeDrawer 5.3";
                     string saveFileName = "TestDrawing.txt";
                     string savePath = System.IO.Path.Combine(saveFolderPath, saveFileName);
                     myDrawing.Save(savePath);

                     Console.WriteLine($"Drawing saved to {savePath}");*/
                }
                if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    string folder = "C:/Users/lequa/OneDrive/Documents/COS20007/ShapeDrawer 5.3/TestDrawing.txt";

                    try
                    {
                        myDrawing.Load(folder);
                        Console.WriteLine($"Drawing loaded from {folder} "); 

                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine("Error loadding file: {0}", e.Message);
                    }
                    /*string LoadFolderPath = @"C:\Users\lequa\OneDrive\Documents\COS20007\ShapeDrawer 5.3";
                    string LoadFileName = "TestDrawing.txt";
                    string LoadPath = System.IO.Path.Combine(LoadFolderPath, LoadFileName);

                    myDrawing.Load(LoadPath);

                    Console.WriteLine($"Drawing load from {LoadPath}");*/
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectedShapeAt(SplashKit.MousePosition());
                }

                if (SplashKit.KeyTyped(KeyCode.BackspaceKey) || SplashKit.KeyTyped(KeyCode.DeleteKey))
                {
                    myDrawing.RemoveShape();
                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = SplashKit.RandomRGBColor(255);
                }

                myDrawing.Draw();

                SplashKit.RefreshScreen();

            } while (!SplashKit.WindowCloseRequested("Drawing Shape"));
        }
    }
}

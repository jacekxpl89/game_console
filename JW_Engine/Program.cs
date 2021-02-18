using OpenTK.Windowing.Desktop;
using System;

namespace JW_Engine
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new NativeWindowSettings();
            c.Size = new OpenTK.Mathematics.Vector2i(800, 800);
            c.Profile = OpenTK.Windowing.Common.ContextProfile.Any;
            c.API = OpenTK.Windowing.Common.ContextAPI.OpenGL;
            c.WindowState = OpenTK.Windowing.Common.WindowState.Normal;
            c.APIVersion = new Version(4,1);
   
            using ( GameWindow ga = new GameWindow(GameWindowSettings.Default,NativeWindowSettings.Default))
            {
                //Run takes a double, which is how many frames per second it should strive to reach.
                //You can leave that out and it'll just update as fast as the hardware will allow it.
              
            }

            Console.Read();
        }
    }
}

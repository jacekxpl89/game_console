using GameEngine.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameEngine
{


    public struct ScreenPixel
    {
        public ConsoleColor background_color;
        public ConsoleColor foreground_color;
        public char icon;

        public ScreenPixel(ConsoleColor background_color, ConsoleColor foreground_color, char icon)
        {
            this.background_color = background_color;
            this.foreground_color = foreground_color;
            this.icon = icon;
        }

        public ScreenPixel(char icon)
        {
            this.background_color = ConsoleColor.Black;
            this.foreground_color = ConsoleColor.White;
            this.icon = icon;
        }
    }

    public class GameManager
    {


        public Action OnStart;
        public Action OnApplicationExit;
        public Action OnUpdate;
        public Action OnScreenRefreshed;
        public Action<ConsoleKey> OnKeyInput;




        public int frames_count = 0;
        protected bool Is_running = false;
        public int refresh = 60;

        private ScreenPixel[,] screen;
        public int height;
        public int width;

        protected ConsoleColor border_color;

        public void SetPixel(int x, int y, char value)
        {
            if (x >= 0 && x <= width && y >= 0 && y <= height)
            {
                screen[y, x] = new ScreenPixel(value);
            }
        }
        public void SetBorder(ConsoleColor color)
        {
            border_color = color;
        }

        public void SetPixel(int x, int y, ScreenPixel value)
        {
            if (x >= 0 && x <= width && y >= 0 && y <= height)
            {
                screen[y, x] = value;
            }
        }

        public void SetPixel(Vector2 point, ScreenPixel value)
        {
            SetPixel(point.x, point.y, value);
        }

        public void SetPixel(Vector2 point, char value)
        {
            SetPixel(point.x, point.y, value);
        }

        public void SetRefreshTime(int refresh)
        {
            this.refresh = refresh;
        }

        public void SetScreenSize(Vector2 size)
        {

            this.screen = new ScreenPixel[size.y, size.x];
            this.height = size.y - 1;
            this.width = size.x - 1;
        }

        public void Start()
        {
            Is_running = true;
            Console.CursorVisible = false;
          
            if (OnStart != null)
                OnStart.Invoke();

            while (Is_running)
            {
                //nie blokuje odswiezania
                if (Console.KeyAvailable && OnKeyInput != null)
                {
                    ConsoleKeyInfo pressed_key = Console.ReadKey(true);
                    OnKeyInput(pressed_key.Key);
                }


                if (OnUpdate != null)
                    OnUpdate.Invoke();

            


                RefreshScreen();

                if (OnScreenRefreshed != null)
                    OnScreenRefreshed.Invoke();

                Thread.Sleep(1000 / refresh);
                ClearScreen();
                frames_count++;
            }
        }

        protected void DrawBorder()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i <= height; i++)
            {
                for (int j = 0; j <= width; j++)
                {
                    Console.BackgroundColor = this.border_color;
                    Console.Write("   ");
                }
                Console.SetCursorPosition(0,  i+1);
            }
             Console.SetCursorPosition(0,  height+3);
        }

        protected void RefreshScreen()
        {
            Console.SetCursorPosition(1, 1);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.BackgroundColor = screen[i, j].background_color;
                    Console.ForegroundColor = screen[i, j].foreground_color;
                    Console.Write(" " + screen[i, j].icon + " ");
                }
                Console.SetCursorPosition(1, i + 1);
            }


        }
        protected void ClearScreen()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    screen[i, j] = new ScreenPixel(' ');
                }
            }
        }

        public void Stop()
        {
            Is_running = false;

            if (OnApplicationExit != null)
            {
                OnApplicationExit.Invoke();
            }
        }


    }
}

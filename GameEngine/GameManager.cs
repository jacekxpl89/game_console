using GameEngine.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameEngine
{
    public class GameManager
    {


        public Action OnStart;
        public Action OnApplicationExit;
        public Action OnUpdate;
        public Action OnScreenRefreshed;
        public Action<ConsoleKey> OnKeyInput;


        public int frames_count = 0;
        private bool Is_running = false;
        private int refresh = 30;

        private char[,] screen;
        public int height;
        public int width;

        public void SetPixel(int x,int y, char value)
        {
            if (x >= 0 && x <= width && y >= 0 && y <= height)
            {
                screen[y, x] = value;
            }
        }

        public void SetPixel(Vector2 point,char value)
        {
            SetPixel(point.x, point.y, value);
        }

        public void SetRefreshTime(int refresh)
        {
            this.refresh = refresh;
        }

        public void SetScreenSize(Vector2 size)
        {
           
            this.screen = new char[size.y, size.x];
            this.height = size.y-1;
            this.width = size.x-1;
        }

        public void Start()
        {
            Is_running = true;

            if (OnStart != null)
                OnStart.Invoke();

            while (Is_running)
            {
                //nie blokuje odswiezania
                if( Console.KeyAvailable && OnKeyInput != null)
                {
                    ConsoleKeyInfo pressed_key = Console.ReadKey(true);
                    OnKeyInput(pressed_key.Key);
                }


                if (OnUpdate != null)
                    OnUpdate.Invoke();

                Console.SetCursorPosition(0, 0);
                RefreshScreen();

                if (OnScreenRefreshed != null)
                    OnScreenRefreshed.Invoke();


               

                Thread.Sleep(1000 / refresh);
              
                ClearScreen();
              
              
               
                frames_count++;

            }
        }

        protected void RefreshScreen()
        {
            for(int i=0;i<height;i++)
            {
                for(int j=0;j<width;j++)
                {
                    Console.Write(" "+screen[i,j]+" ");
                }
                Console.WriteLine("");
            }
            //clean gui
          
        }
        protected void ClearScreen()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    screen[i, j] = ' ';
                }
            }

            string result = "";
            for (int j = 0; j < this.width; j++)
            {
                result += "   ";
            }
            for (int i=0;i<5;i++)
            {
                Console.SetCursorPosition(0, this.height+i);
              
                Console.WriteLine(result);
            }
          
        }

        public void Stop()
        {
            Is_running = false;

            if(OnApplicationExit != null)
            {
                OnApplicationExit.Invoke();
            }
        }


    }
}

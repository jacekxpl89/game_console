using GameEngine.CallOfDuty;
using GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Program
    {


        public class Gracz : GameObject
        {



            public override void ApplicationExit()
            {

            }
            public override void OnColision(GameObject colider)
            {



            }
            public override void Start()
            {
                this.model = 'O';
                this.tag = "Gracz";
                this.background_color = ConsoleColor.Red;
                Unity.Camera_LookAt(this);

            }




            public override void Update()
            {


            }
            public override void OnKeyPressed(ConsoleKey key)
            {
                switch (key)
                {
                    case ConsoleKey.W:
                        position.y++;
                        break;
                    case ConsoleKey.S:
                        position.y--;
                        break;
                    case ConsoleKey.A:
                        position.x++;
                        break;
                    case ConsoleKey.D:
                        position.x--;
                        break;
                    case ConsoleKey.Spacebar:
                        Unity.Add_GameObject(new Bullet(), this.position);
                        break;
                }
            }
        }


        [STAThread]
        static void Main(string[] args)
        {

            Console.Title = "Łapanka varszawa 1944 Polecam Magda Gesler ";

            for (int i = 0; i < 10; i++)
            {
                Niemiec nowy_niemiec = new Niemiec();
                nowy_niemiec.AI = false;
                Unity.Add_GameObject(nowy_niemiec, new Vector2(Unity.Random(-11, 5), Unity.Random(-5, 11)));
                Unity.Add_GameObject(new Polak(), new Vector2(Unity.Random(-11, 5), Unity.Random(-5, 11)));
            }


            for (int i = -5; i < 5; i++)
            {

                for (int j = -5; j < 5; j++)
                {

                    if (ComplexMath.GetDistnace(new Vector2(0, 0), new Vector2(i, j)) < 6)
                    {
                        Unity.Add_GameObject(new MapTile(MapTileType.Water), new Vector2(i,j));
                    }
                   
                }
            }



            Unity.Add_GameObject(new Gracz(), new Vector2(3, 0));
            Unity.Start();




        }



    }
}

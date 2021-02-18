using GameEngine.CallOfDuty;
using GameEngine.Math;
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
                this.background_color = ConsoleColor.DarkYellow;
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
                }
            }
        }


        [STAThread]
        static void Main(string[] args)
        {
            for(int i=0;i<5;i++)
            {
                 Unity.Add_GameObject(new MapTile(MapTileType.Grass), new Vector2(1, i));
                 Unity.Add_GameObject(new MapTile(MapTileType.Water), new Vector2(1, i+8));
            }

            Unity.Add_GameObject(new Gracz(), new Vector2(4, 4));
            Unity.Start();
        }



    }
}

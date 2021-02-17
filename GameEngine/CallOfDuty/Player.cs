using GameEngine.GUI;
using GameEngine.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.CallOfDuty
{
    public class Player : GameObject
    {

        Inventory inventory;

        public override void ApplicationExit()
        {

        }

        public override void Start()
        {
            this.position = new Vector2(5, 5);
            this.model = '@';
            this.name = "player";

            inventory = new Inventory();
            this.childs.Add(inventory);
            Unity.Camera_LookAt(this);
        }

        public override void Update()
        {
           
        }

        public override void OnColision(GameObject colider)
        {
            inventory.Add_item();
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
}

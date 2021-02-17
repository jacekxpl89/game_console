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
        public override void Awake()
        {
        
        }
        public override void Start()
        {
            this.position = new Vector2(5, 5);
            this.model = '5';

            inventory = new Inventory();
            this.childs.Add(inventory);

            Unity.instnace.OnKeyInput += PlayerMovement;
        }

        public  void PlayerMovement(ConsoleKey consoleKey)
        {
           switch(consoleKey)
            {
                case ConsoleKey.W:
                    this.position.y--;
                    break;
                case ConsoleKey.S:
                    this.position.y++;
                    break;
                case ConsoleKey.A:
                    this.position.x--;
                    break;
                case ConsoleKey.D:
                    this.position.x++;
                    break;
                case ConsoleKey.I:
                    inventory.Is_open = !inventory.Is_open;
                    break;
            }
        }

        public override void Update()
        {
           
        }

        public override void OnColision(GameObject colider)
        {
            inventory.Add_item();
        }
    }
}

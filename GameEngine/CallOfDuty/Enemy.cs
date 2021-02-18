using GameEngine.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.CallOfDuty
{
    public class Enemy : GameObject
    {
        public override void ApplicationExit()
        {

        }



        public override void OnColision(GameObject colider)
        {
          

        }

        public override void OnKeyPressed(ConsoleKey key)
        {

        }

        public Random random;
        public override void Start()
        {
            this.tag = "Enemy";
            this.background_color = ConsoleColor.Red;
            this.model = ';';

            random = new Random();
        }
        public int i = 0;
        public bool AI = true;
        public override void Update()
        {

            if (i % 15 == 0 && AI)
            {
                this.position.x = this.position.x + Unity.Random(-2, 2);
                this.position.y = this.position.y + Unity.Random(-2, 2);
            }
            i++;

          


        }
    }
}

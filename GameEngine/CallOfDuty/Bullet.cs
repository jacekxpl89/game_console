using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.CallOfDuty
{
    public class Bullet : GameObject
    {

        List<ConsoleColor> colors = new List<ConsoleColor>();
        public override void ApplicationExit()
        {

        }



        public override void OnColision(GameObject colider)
        {
            if (colider.name != "player" && colider.name != "bullet")
            {
                mn = !mn;
            }
        }

        public override void Start()
        {
            this.model = '<';
            this.name = "bullet";
            colors.Add(ConsoleColor.Yellow);
            colors.Add(ConsoleColor.DarkYellow);
            colors.Add(ConsoleColor.Red);
            colors.Add(ConsoleColor.DarkRed);
        }
        int i = 0;
        bool mn = false;
        public override void Update()
        {
            this.background_color = colors[i % colors.Count];
            i++;
            if (mn)
                this.position.x = (this.position.x + 1);
            else
                this.position.x = (this.position.x - 1);
        }

        public override void OnKeyPressed(ConsoleKey key)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.CallOfDuty
{
    public class Polak : Enemy
    {



        public override void Start()
        {
            base.Start();

            this.tag = "Polak";
            this.model = '$';
            this.foreground_color = ConsoleColor.Red;
            this.background_color = ConsoleColor.White;
        }

        public override void Update()
        {
            base.Update();

           
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.CallOfDuty
{
   public class Niemiec : Enemy
    {

        public static int Zlapani_polacy = 0;

  

        public override void Start()
        {
            base.Start();


            this.model = '@';
            this.name = "NIemiec";
            this.background_color = ConsoleColor.DarkRed;
            this.foreground_color = ConsoleColor.DarkYellow;


        }


        public override void OnColision(GameObject colider)
        {
            base.OnColision(colider);


            if(colider is Polak)
            {
                Zlapani_polacy++;
                Console.WriteLine("Polak złapany " + Zlapani_polacy);
                colider.Destory();
            }
        }

        public override void Update()
        {
            base.Update();


            if (i % 15 == 0)
            {
                foreach (var gameobject in Unity.GameObject_in_Range(this.position, 5))
                {
                    if (gameobject is Polak)
                    {
                        Vector2 direction = this.position - gameobject.position;

                        direction.x = direction.x == 0 ? 0 : (direction.x / Math.Abs(direction.x));
                        direction.y = direction.y == 0 ? 0 : (direction.y / Math.Abs(direction.y));



                        this.position -= direction;
                    }
                }
            }
        }
    }
}

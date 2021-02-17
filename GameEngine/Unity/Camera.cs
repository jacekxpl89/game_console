using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Camera : GameObject
    {

       public  GameObject target;
        public void LookAt(GameObject gameObject)
        {
            target = gameObject;
        }
        public override void ApplicationExit()
        {
          
        }

        public override void OnColision(GameObject colider)
        {
           
        }

        public override void OnKeyPressed(ConsoleKey key)
        {
      
        }

        public override void Start()
        {
            this.enableColision = false;
        }

        public override void Update()
        {
            if(target != null)
            {
                this.position = target.position;
            }
      
          
        }
    }
}

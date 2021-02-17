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

        public override void Awake()
        {
           
        }

        public override void OnColision(GameObject colider)
        {
         
        }

        public override void Start()
        {
            this.position = new Math.Vector2(3, 3);
            this.name = "Enemy";
            this.model = '&';
        }

        public override void Update()
        {
         
        }
    }
}

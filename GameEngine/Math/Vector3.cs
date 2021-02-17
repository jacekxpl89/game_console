using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Math
{
    public class Vector3 : Vector2
    {

        public int z;


        public Vector3()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        public Vector3(int x,int y,int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}

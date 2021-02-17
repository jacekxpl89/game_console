using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Math
{
    public class Vector2
    {
        public int x;
        public int y;


        public Vector2()
        {
            x = 0;
            y = 0;
        }

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            Vector2 vector2 = (Vector2)obj;

            if(vector2.x == this.x && vector2.y == this.y)
            {
                return true;
            }

            return false;
        }
    }
}

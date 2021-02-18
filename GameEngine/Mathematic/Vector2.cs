using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public struct Vector2
    {
        public int x;
        public int y;


        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x + v2.x, v1.y + v2.y);
        }
        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x - v2.x, v1.y - v2.y);
        }

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $" X:{x}  Y:{y}";
        }

        public override bool Equals(object obj)
        {
            Vector2 vector2 = (Vector2)obj;

            if (vector2.x == this.x && vector2.y == this.y)
            {
                return true;
            }

            return false;
        }
    }
}

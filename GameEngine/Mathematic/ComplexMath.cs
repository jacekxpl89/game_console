using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
   public class ComplexMath
    {


        public static int GetDistnace(Vector2 p1, Vector2 p2) => (int)Math.Sqrt((p1.x - p2.x) * (p1.x - p2.x) + (p1.y - p2.y) * (p1.y - p2.y));






    }
}

using GameEngine.CallOfDuty;
using GameEngine.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Program
    {
        static void Main(string[] args)
        {

            

            Unity unitygameengine = new Unity();


            unitygameengine.SetScreenSize(new Vector2(15, 15));

            for (int i = 0; i <= unitygameengine.height; i++)
            {
                for (int j = 0; j <= unitygameengine.width; j++)
                {
                    if(i==0|| j==0|| i == unitygameengine.width-1|| unitygameengine.height-1 == j)
                      unitygameengine.Add_gameobject(new MapTile(new Vector2(j, i), MapTileType.Stone));
                } 
            }
            
            unitygameengine.Add_gameobject(new MapTile(new Vector2(7, 7), MapTileType.Tree));

            unitygameengine.Add_gameobject(new Enemy());
            unitygameengine.Add_gameobject(new Player());
            unitygameengine.Start();



        }

     

    }
}

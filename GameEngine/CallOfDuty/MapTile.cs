using GameEngine.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.CallOfDuty
{

    public enum MapTileType
    {
        Grass, Tree, Stone, Water
    }
    public class MapTile : GameObject
    {
        MapTileType type;

        public MapTile( MapTileType type)
        {
            this.type = type;
            this.SetModel(type);
        }

        public void SetModel(MapTileType type)
        {
            switch (type)
            {
                case MapTileType.Grass:
                    this.background_color = ConsoleColor.Green;
                    break;
                case MapTileType.Tree:
                    this.background_color = ConsoleColor.DarkGreen;
                    break;
                case MapTileType.Stone:
                    this.background_color = ConsoleColor.Gray;
                    break;
                case MapTileType.Water:
                    this.background_color = ConsoleColor.Blue;
                    break;
            }
        }

        public override void ApplicationExit()
        {

        }

   
        public override void OnColision(GameObject colider)
        {
           
        }

        public override void Start()
        {
            this.name = "Tile: " + this.type.ToString();
        }

        public override void Update()
        {

        }

        public override void OnKeyPressed(ConsoleKey key)
        {
          
        }
    }
}

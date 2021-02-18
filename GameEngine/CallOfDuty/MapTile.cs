using GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.CallOfDuty
{

    public enum MapTileType
    {
        Grass, Tree, Stone, Water, Lava
    }
    public class MapTile : GameObject
    {
        public MapTileType type;

        public MapTile(MapTileType type)
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
                    break;
                case MapTileType.Lava:
                    this.background_color = ConsoleColor.Yellow;
                    break;
            }
        }

        public override void ApplicationExit()
        {

        }


        public override void OnColision(GameObject colider)
        {
            if (this.type == MapTileType.Lava)
            {
                colider.Destory();
            }
        }
        List<char> animations = new List<char>();
        public override void Start()
        {
            this.name = "Tile: " + this.type.ToString();
            animations.Add('`');
            animations.Add('~');
            animations.Add('>');
            animations.Add('~');
            animations.Add('<');
        }
        int i = 0;
        public override void Update()
        {
            if (i % 2 == 0 && this.type == MapTileType.Water)
            {
                this.model = animations[i % animations.Count];

            }
            i++;
        }

        public override void OnKeyPressed(ConsoleKey key)
        {

        }
    }
}

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
        Grass, Tree, Stone
    }
    public class MapTile : GameObject
    {
        MapTileType type;

        public MapTile(Vector2 position, MapTileType type)
        {
            this.type = type;
            this.SetModel(type);
            this.SetPosition(position);
        }

        public void SetModel(MapTileType type)
        {
            switch(type)
            {
                case MapTileType.Grass:
                    this.model = '#';
                    break;
                case MapTileType.Tree:
                    this.model = '/';
                    break;
                case MapTileType.Stone:
                    this.model = '^';
                    break;
            }
        }

        public override void ApplicationExit()
        {
          
        }

        public override void Awake()
        {
          
        }

        public override void OnColision(GameObject colider)
        {
            this.Destory();
        }

        public override void Start()
        {
            this.name = "Tile: "+this.type.ToString();
        }

        public override void Update()
        {
           
        }
    }
}

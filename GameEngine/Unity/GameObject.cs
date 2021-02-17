using GameEngine.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public abstract class GameObject
    {

        public string id = Guid.NewGuid().ToString();
        public string name = string.Empty;
        public string tag = string.Empty;
        public List<GameObject> childs = new List<GameObject>();
        public char model = ' ';
        public bool active = true;
        public bool destoryed = false;
        public Vector2 position;
        public Vector2 last_position;
        public bool enableColision = true;
        public ConsoleColor background_color = ConsoleColor.Black;
        public ConsoleColor foreground_color = ConsoleColor.White;

        //wykounje sie po awake
        public abstract void Start();

        //wykonuje sie co kazdą klatke
        public abstract void Update();

        public abstract void OnKeyPressed(ConsoleKey key);

        public abstract void OnColision(GameObject colider);

        //wykonuje sie przy wylaczeniu apikacji
        public abstract void ApplicationExit();

        public virtual void Destory()
        {
            destoryed = true;
            Unity.Delete_GameObject(this);
        }




        public void SetPosition(Vector2 position)
        {
            this.last_position = position;
            this.position = position;
        }




    }
}

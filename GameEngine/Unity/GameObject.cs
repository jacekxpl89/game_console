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

        //wykonuje sie totalnie po starcie aplikacji
        public abstract void Awake();

        //wykounje sie po awake
        public abstract void Start();

        //wykonuje sie co kazdą klatke
        public abstract void Update();

        public abstract void OnColision(GameObject colider);

        //wykonuje sie przy wylaczeniu apikacji
        public abstract void ApplicationExit();

        public virtual void Destory()
        {
            destoryed = true;
        }

        public char model = ' ';
        public bool destoryed = false;
        public Vector2 position;
        public Vector2 last_position;
        public bool Is_colision = true;

        public void SetPosition(Vector2 position)
        {
            this.last_position = position;
            this.position = position;
        }


        public string id = Guid.NewGuid().ToString();

        public String name;

        public List<GameObject> childs = new List<GameObject>();

    }
}

using GameEngine.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Unity : GameManager
    {


        public static Unity instnace;


        List<GUI_Element> GUI_to_draw = new List<GUI_Element>();
        List<GameObject> gameObjects = new List<GameObject>();
        List<GameObject> to_destory = new List<GameObject>();
        public Unity()
        {
            instnace = this;

            this.OnUpdate += UnityUpdate;
            this.OnStart += UnityStart;
            this.OnApplicationExit += UnityStop;
            this.OnScreenRefreshed += UnityDrawGUI;
        }


        private void UnityDrawGUI()
        {
            foreach(var g in GUI_to_draw)
            {
                g.Draw();
            }
            GUI_to_draw.Clear();
        }

        private void UnityStart()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Awake();
                gameObjects[i].childs.ForEach(c => c.Awake());
            }

            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Start();
                gameObjects[i].childs.ForEach(c => c.Start());
            }
        }
        private void UnityUpdate()
        {
            foreach(GameObject gameObject in gameObjects)
            {
                //sprawdzanie kolizji
                if(gameObject.destoryed)
                {
                    to_destory.Add(gameObject);
                    continue;
                }


                foreach(GameObject go in gameObjects)
                {
                    if(gameObject.Is_colision &&   go.Is_colision &&  gameObject.id.Equals(go.id) == false && gameObject.position.Equals(go.position))
                    {
                       gameObject.OnColision(go);
                    }
                }

                //rysowanie
                this.SetPixel(gameObject.position, gameObject.model);
                gameObject.Update();
                gameObject.childs.ForEach(c => c.Update());
            }


            to_destory.ForEach(g => this.gameObjects.Remove(g));
            to_destory.Clear();

        }
        private void UnityStop()
        {
            foreach (var gameObject in gameObjects)
            {
                gameObject.ApplicationExit();
                gameObject.childs.ForEach(c => c.ApplicationExit());
            }
        }

        public void Add_gameobject(GameObject gameObject)
        {
            if(gameObjects.Contains(gameObject) == false)
            {
                gameObjects.Add(gameObject);
            }
        }
        public void Remove_gameobject(GameObject gameObject)
        {
            if (gameObjects.Contains(gameObject) == true)
            {
                gameObjects.Remove(gameObject);
            }
        }


        public void  Add_GUI(GUI_Element gUI_Element)
        {
            this.GUI_to_draw.Add(gUI_Element);
        }



    }
}

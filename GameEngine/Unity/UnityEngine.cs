using GameEngine.GUI;
using GameEngine.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class UnityEngine : GameManager
    {


        public static UnityEngine Instnace
        {
            get
            {
                if (instance == null)
                {
                    instance = new UnityEngine();
                }

                return instance;
            }
        }


        private static UnityEngine instance;

        private List<GUI_Element> GUI_to_draw = new List<GUI_Element>();
        private List<GameObject> to_destory = new List<GameObject>();
        private List<string> messages_to_show = new List<string>();

        public List<GameObject> gameObjects = new List<GameObject>();
        public Camera camera = new Camera();
        public ConsoleKey inputkey;

        public UnityEngine()
        {

            this.OnUpdate += UnityUpdate;
            this.OnStart += UnityStart;
            this.OnApplicationExit += UnityStop;
            this.OnScreenRefreshed += UnityDrawGUI;
            this.OnKeyInput += UnityKeyPressed;
        }
        private void UnityKeyPressed(ConsoleKey key)
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i].active)
                {
                    gameObjects[i].OnKeyPressed(key);
                    gameObjects[i].childs.ForEach(child => child.OnKeyPressed(key));
                }
            }

            //  inputkey = key;
        }

     

        private void UnityDrawGUI()
        {
            int size = 0;
            foreach (var g in GUI_to_draw)
            {
                g.Draw();
                size += g.image.Count;
            }
            GUI_to_draw.Clear();
        }

        private void UnityStart()
        {
            this.SetBorder(ConsoleColor.DarkGreen);
            this.DrawBorder();
            this.Add_gameobject(camera);

            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Start();
                gameObjects[i].childs.ForEach(c => c.Start());
            }
        }
        private void UnityUpdate()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                if (gameObject.active == false)
                {
                    continue;
                }

                foreach (GameObject go in gameObjects)
                {
                    if (go.enableColision &&
                        go.active &&
                        gameObject.enableColision &&
                        gameObject.id.Equals(go.id) == false &&
                        gameObject.position.Equals(go.position))
                    {
                        gameObject.OnColision(go);
                    }
                }
                gameObject.Update();
                gameObject.childs.ForEach(c => c.Update());
                if (gameObject != camera)
                {
                    Vector2 point_to_screen = camera.position - gameObject.position;
                    point_to_screen.x += this.width / 2;
                    point_to_screen.y += this.height / 2;
                    this.SetPixel(point_to_screen, new ScreenPixel(gameObject.background_color, gameObject.foreground_color, gameObject.model));
                }


            }

            foreach (GameObject gameObject in to_destory)
            {
                gameObjects.Remove(gameObject);
            }
            to_destory.Clear();

            inputkey = ConsoleKey.MediaPlay;
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
            if (gameObjects.Contains(gameObject) == false)
            {
                gameObjects.Add(gameObject);
            }
        }

        public void Add_gameobject(GameObject gameObject, Vector2 position)
        {
            if (gameObjects.Contains(gameObject) == false)
            {
                gameObject.position = position;
                gameObjects.Add(gameObject);


                if (this.Is_running)
                {
                    gameObject.Start();
                    gameObject.childs.ForEach(c => c.Start());
                }

            }
        }

        public void Remove_gameobject(GameObject gameObject)
        {
            to_destory.Add(gameObject);
        }


        public void Add_GUI(GUI_Element gUI_Element)
        {
            this.GUI_to_draw.Add(gUI_Element);
        }



    }
}

using GameEngine.GUI;
using GameEngine.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Unity
    {
        public static void Start()
        {
            UnityEngine.Instnace.SetScreenSize(new Vector2(20, 20));
            UnityEngine.Instnace.Start();
        }

        public static void Stop()
        {
            UnityEngine.Instnace.Stop();
        }
        public static void Camera_LookAt(GameObject gameObject)
        {
            UnityEngine.Instnace.camera.LookAt(gameObject);
        }

        public static void Add_GameObject(GameObject gameObject, Vector2 position)
        {
            UnityEngine.Instnace.Add_gameobject(gameObject, position);
        }

        public static void Add_GameObject(GameObject gameObject)
        {
            UnityEngine.Instnace.Add_gameobject(gameObject, gameObject.position);
        }
        public static void Add_GUI(GUI_Element GUI_Element)
        {
            UnityEngine.Instnace.Add_GUI(GUI_Element);
        }
        public static void Delete_GameObject(GameObject gameObject)
        {
            UnityEngine.Instnace.Remove_gameobject(gameObject);
        }


    }
}

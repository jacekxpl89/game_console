﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GUI
{
    public  class GUI_Message :GUI_Element
    {

        public GUI_Message(string text)
        {
            this.image.Add(this.Add_Bar(UnityEngine.Instnace.width, '*'));
            this.image.Add(this.Add_text_center(UnityEngine.Instnace.width, text));
            this.image.Add(this.Add_Bar(UnityEngine.Instnace.width, '*'));
        }

        public GUI_Message(List<string> messages)
        {
            this.image.Add(this.Add_Bar(UnityEngine.Instnace.width, '*'));
            foreach(var m in messages)
            {
                this.image.Add(this.Add_text_center(UnityEngine.Instnace.width, m));
            }
            this.image.Add(this.Add_Bar(UnityEngine.Instnace.width, '*'));
        }


    }
}

using GameEngine.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.CallOfDuty
{


    public struct Item
    {
        public char icon;
        public int amount;
        public string name;

        public Item(char icon,  string name)
        {
            this.icon = icon;
            this.amount = 0;
            this.name = name;
        }
    }

    public class Inventory : GameObject
    {
        public bool Is_open;
        public List<Item> items = new List<Item>();
        

        public void Add_item()
        {
            items.Add(new Item('$', "Cos"));
        }
        public void Remove_item()
        {

        }


        public override void Start()
        {
          
        }

        public override void Update()
        {
            if(Is_open)
            {
                Unity.Add_GUI(new GUI_Message("Przedmioty: " + items.Count));
            }
        }

        public override void OnColision(GameObject colider)
        {
          
        }

        public override void ApplicationExit()
        {
            
        }

        public override void OnKeyPressed(ConsoleKey key)
        {

        }
    }
}

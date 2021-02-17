using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GUI
{
    public class GUI_Element
    {


        public List<string> image = new List<string>();

        public string Add_text_center(int size, string text)
        {
            string result = string.Empty;


            for (int i = 0; i < size/2; i++)
            {
                result += $"  ";
            }
            result += text;
            return result;
        }
        public string Add_Bar(int size,char icon)
        {
            string result = string.Empty;


            for(int i =0;i<size;i++)
            {
                result += $" {icon} ";
            }
            return result;
        }

        public void Draw()
        {
            foreach(string i in image)
            {
                 Console.WriteLine(i );
            }
        }

    }
}

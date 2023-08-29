using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_first_3D_Engine
{
    internal class constructor
    {
        private TextBox textbox;
        public constructor(TextBox textbox) 
        {  
            this.textbox = textbox;
        }

        public objectModel modelReader()
        {
            string text = null;
            string fileName = null;

            int x = 0; //Number of lines

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Counting the number of lines without name line

            StreamReader counter = new StreamReader(@".\Models\test.txt");
            text = counter.ReadLine();

            if (text != null)
            {
                while (!counter.EndOfStream)
                {
                    x++;
                    text = counter.ReadLine();
                }
            }
            counter.Close();


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Reading the lines

            //Identifying the model
            objectModel result = new objectModel(fileName, new Triangle[x]);

            //Start reading the text file
            char[] separators = new char[] { ' ' }; //Separators for the text
            StreamReader sr = new StreamReader(@".\Models\test.txt");
            text = sr.ReadLine();
            result.name = text; //First line is the name of the object
            string[] subs;

            
                for (int i = 0; i < result.mesh.Length; i++)
                {
                    text = sr.ReadLine();
                    subs = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    result.mesh[i] = new Triangle(new point[] { new point(Convert.ToDouble(subs[0]), Convert.ToDouble(subs[1]), Convert.ToDouble(subs[2])), new point(Convert.ToDouble(subs[3]), Convert.ToDouble(subs[4]), Convert.ToDouble(subs[5])), new point(Convert.ToDouble(subs[6]), Convert.ToDouble(subs[7]), Convert.ToDouble(subs[8])) });
                }
            
            textbox.Text = textbox.Text + Environment.NewLine + Environment.NewLine + result.name;

            for (int i = 0; i < x; i++)
            {
                textbox.Text = textbox.Text + Environment.NewLine;
                for (int j = 0; j < 3; j++)
                {
                    textbox.Text = textbox.Text + i.ToString() + j.ToString() + " ";
                    textbox.Text = textbox.Text + " " + result.mesh[i].points[j].x.ToString();
                    textbox.Text = textbox.Text + " " + result.mesh[i].points[j].y.ToString();
                    textbox.Text = textbox.Text + " " + result.mesh[i].points[j].z.ToString();
                    textbox.Text = textbox.Text + Environment.NewLine;
                }
            }
            return result;
        }
    }
}

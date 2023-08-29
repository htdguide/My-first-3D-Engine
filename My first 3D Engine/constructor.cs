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
        public objectModel resultModel;
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

            //Identifying the points
            point point = new point(0,0,0);
            point[] points = new point[3];
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = point;
            }

            //Identifying the triangles
            Triangle triangle = new Triangle(points);
            Triangle[] triangles = new Triangle[x]; //Array of triangles
            for (int i = 0; i < triangles.Length; i++)
            {
                triangles[i] = triangle;
            }

            //Identifying the model
            objectModel result = new objectModel(fileName, triangles);

            //Start reading the text file
            char[] separators = new char[] { ' ' }; //Separators for the text
            StreamReader sr = new StreamReader(@".\Models\test.txt");
            text = sr.ReadLine();
            result.name = text; //First line is the name of the object
            string[] subs;
            if (text != null)
            {
                for (int i = 0; i < result.mesh.Length; i++)
                {
                    text = sr.ReadLine();
                    subs = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    for (int j = 0; j < subs.Length; j++)
                    {
                        textbox.Text = textbox.Text + subs[j];
                    }
                    textbox.Text = textbox.Text + Environment.NewLine;

                    result.mesh[i].points[0].x = Convert.ToDouble(subs[0]);
                    result.mesh[i].points[0].y = Convert.ToDouble(subs[1]);
                    result.mesh[i].points[0].z = Convert.ToDouble(subs[2]);

                    result.mesh[i].points[1].x = Convert.ToDouble(subs[3]);
                    result.mesh[i].points[1].y = Convert.ToDouble(subs[4]);
                    result.mesh[i].points[1].z = Convert.ToDouble(subs[5]);

                    result.mesh[i].points[2].x = Convert.ToDouble(subs[6]);
                    result.mesh[i].points[2].y = Convert.ToDouble(subs[7]);
                    result.mesh[i].points[2].z = Convert.ToDouble(subs[8]);
                }
            }
            textbox.Text = textbox.Text + result.name;

            for (int i = 0; i < result.mesh.Length; i++)
            {
                for (int j = 0; j < result.mesh[i].points.Length; j++)
                {
                    textbox.Text = textbox.Text + Environment.NewLine + result.mesh[i].points[j].x.ToString();
                    textbox.Text = textbox.Text + result.mesh[i].points[j].y.ToString();
                    textbox.Text = textbox.Text + result.mesh[i].points[j].z.ToString();
                }
            }
            return result;
        }
    }
}

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
        public constructor() 
        { 
        
        }

        public objectModel modelReader()
        {
            string text, fileName;
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

            //Start reading the text file
            char[] separators = new char[] { ' ' }; //Separators for the text
            StreamReader sr = new StreamReader(@".\Models\test.txt");
            text = sr.ReadLine();
            fileName = text;
            string[] subs; //array for text division

            if (text != null)
            {
                fileName = text; //First line is the name of the object
                for (int i = 0; i < triangles.Length; i++)
                {
                    text = sr.ReadLine();
                    subs = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    triangles[i].points[0].x = Convert.ToDouble(subs[0]);
                    triangles[i].points[0].y = Convert.ToDouble(subs[1]);
                    triangles[i].points[0].z = Convert.ToDouble(subs[2]);

                    triangles[i].points[1].x = Convert.ToDouble(subs[3]);
                    triangles[i].points[1].y = Convert.ToDouble(subs[4]);
                    triangles[i].points[1].z = Convert.ToDouble(subs[5]);

                    triangles[i].points[2].x = Convert.ToDouble(subs[6]);
                    triangles[i].points[2].y = Convert.ToDouble(subs[7]);
                    triangles[i].points[2].z = Convert.ToDouble(subs[8]);
                }
            }
            objectModel objectModel = new objectModel(fileName, triangles);
            return objectModel;
        }
    }
}

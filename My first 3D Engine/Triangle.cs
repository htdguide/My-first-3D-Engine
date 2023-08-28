using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_first_3D_Engine
{
    internal class Triangle
    {
        public string name; //triangle id
        public Color color = Color.White; //Color of triangle
        public point[] points = new point[3]; //3 points for triangle
        public Triangle(point[] points) 
        { 
            this.points = points;
        }
    }
}

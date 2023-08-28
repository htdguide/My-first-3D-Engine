using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_first_3D_Engine
{
    internal class objectModel 
    {
        public string name; //Object name
        public Triangle[] mesh; //array of triangles
        
        public objectModel(string name, Triangle[] mesh)
        {
            this.name = name;
            this.mesh = mesh;
        }

    }
}

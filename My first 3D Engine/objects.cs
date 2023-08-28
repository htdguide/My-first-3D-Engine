using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_first_3D_Engine
{
    internal class objects //Final object
    {
        public string name;
        public objectModel model;
        public objects(string name, objectModel model)
        {
            this.name = name;
            this.model = model;
        }
    }
}

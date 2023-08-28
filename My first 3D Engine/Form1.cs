using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_first_3D_Engine
{
    public partial class Form1 : Form
    {
        constructor constructor;

        public Form1()
        {
            constructor = new constructor();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            objectModel test = constructor.modelReader();

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_first_3D_Engine
{
    public partial class Form1 : Form
    {
        public Panel panel1;
        constructor constr;
        projection proj;
        objectModel testProj, test;
        

        public Form1()
        {
            InitializeComponent();
            proj = new projection(displayPanel, textBox1);
            constr = new constructor(textBox1);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            test = constr.modelReader();
            testProj = proj.createProjection(test);
            proj.drawModel(testProj);
        }
    }
}

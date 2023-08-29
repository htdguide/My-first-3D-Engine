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
        objectModel testProj, model, mtest, ptest;
        modifications modif;
        double x = 0;


        public Form1()
        {
            InitializeComponent();
            proj = new projection(displayPanel, textBox1);
            constr = new constructor(textBox1);
            modif = new modifications(textBox1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            model = constr.modelReader();
            model = modif.objectMove(model, 0, 0, x);
            mtest = proj.funk(model);
            mtest = proj.createProjection(mtest);
            proj.drawModel(mtest);
            x = x + 0.1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}

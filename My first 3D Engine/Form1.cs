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
        modfications modif;
        int x = 1;


        public Form1()
        {
            InitializeComponent();
            proj = new projection(displayPanel, textBox1);
            constr = new constructor(textBox1);
            modif = new modfications(textBox1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            test = modif.RotateXY(test, 1);
            testProj = proj.createProjection(test);
            proj.drawModel(testProj);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            test = constr.modelReader();
            test = modif.objectScale(test, 100);
            test = modif.objectMove(test, 20, 20, 1);
            
            timer1.Enabled = true;
        }
    }
}

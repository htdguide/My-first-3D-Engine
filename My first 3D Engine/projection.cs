using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_first_3D_Engine
{
    internal class projection
    {
        private Panel panel1;
        private TextBox textBox1;
        double aspectRatio;
        double zFar = 1000; //Farest point
        double zNear = 0.1; //Nearest point
        double FOVAngle = 90; //Field of view
        double f, q;
        double[,] projMatrix = new double[4,4]; //Projection matrix

        public projection(Panel panel1, TextBox textBox1)
        {
            this.panel1 = panel1;
            this.textBox1 = textBox1;
        }

        public objectModel createProjection(objectModel model)
        {
           objectModel result = new objectModel("projected", model.mesh);


            //Projection matrix filling
           aspectRatio = panel1.Height/panel1.Width;
           f = 1 / Math.Tan(FOVAngle * 0.5 / 180 * Math.PI); //Field of view in radians
           q = zFar / (zFar - zNear);
           projMatrix[0,0] = aspectRatio * f;
           projMatrix[1,1] = f;
           projMatrix[2, 2] = q;
           projMatrix[2,3] = 1.0;
           projMatrix[3, 2] = -zNear * q;
           projMatrix[3,3] = 0;

            for (int i = 0; i < model.mesh.Length; i++)
            {
                for (int j = 0; j < model.mesh[i].points.Length; j++)
                {
                   result.mesh[i].points[j] = multiplyByMatrix(model.mesh[i].points[j], projMatrix);
                }
           }
           return result;
        }

        public void drawModel(objectModel model) //Should be already projected model
        {
            for (int i = 0; i < model.mesh.Length; i++)
            {
                drawTriangle(model.mesh[i]);
            }
        }

        public void drawTriangle(Triangle triangle)
        {
            Graphics g = panel1.CreateGraphics();
            Pen pen = new Pen(triangle.color);
            PointF[] t = new PointF[3];
            t[0] = new Point(Convert.ToInt32(triangle.points[0].x), Convert.ToInt32(triangle.points[0].y));
            t[1] = new Point(Convert.ToInt32(triangle.points[1].x), Convert.ToInt32(triangle.points[1].y));
            t[2] = new Point(Convert.ToInt32(triangle.points[2].x), Convert.ToInt32(triangle.points[2].y));
            g.DrawPolygon(pen, t);
        }
           

        public point multiplyByMatrix(point p, double[,] m)
        {
           // textBox1.Text = textBox1.Text + Environment.NewLine + p.x.ToString();
           // textBox1.Text = textBox1.Text + Environment.NewLine + p.y.ToString();
           // textBox1.Text = textBox1.Text + Environment.NewLine + p.z.ToString();
           // textBox1.Text = textBox1.Text + Environment.NewLine;

            point result = new point(0,0,0);
            result.x = p.x * m[0,0] + p.y * m[1,0] + p.z * m[2,0] + m[3,0];
            result.y = p.x * m[0,1] + p.y * m[1,1] + p.z * m[2,1] + m[3,1];
            result.z = p.x * m[0,2] + p.y * m[1,2] + p.z * m[2,2] + m[3,2];
            double w = p.x * m[0,3] + p.y * m[1,3] + p.z * m[2,3] + m[3,3];
            if (w != 0.0)
            {
                result.x /= w;
                result.y /= w;
                result.z /= w;
            }
            return result;
        }

        public double[][] linearTrasformation(double[][] f, double[] y) //Linear transformation method
        {
            double[][] result = new double[4][];
            for (int i = 0; i < 3; i++)
            {
                for (int i2 = 0; i2 < 3; i2++)
                {
                    result[i][i2] = result[i][i2] + f[i][i2] * y[i2];
                }
            }
            return result;
        }
    }
}

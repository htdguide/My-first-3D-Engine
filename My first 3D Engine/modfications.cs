using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_first_3D_Engine
{
    internal class modfications
    {
        TextBox textbox;
        public modfications(TextBox textbox) 
        {
            this.textbox = textbox;
        }

        public point linearTransformation(point point, double[,] f)
        {
            point result = new point(0,0,0);


            for (int i = 0; i < f.Rank; i++)
            {
                result.x = result.x + f[0,i] * point.x;
                result.y = result.y + f[1,i] * point.y;
                result.z = result.z + f[2,i] * point.z;
            }
            return result;
        }

        public objectModel modelLinearTransformation(objectModel model, double[,] f)
        {
            objectModel result = model;

            for (int i = 0; i < model.mesh.Length; i++)
            {
                for (int j = 0; j < model.mesh[i].points.Length; j++)
                {
                    result.mesh[i].points[j] = linearTransformation(model.mesh[i].points[j], f);
                }
            }
            return result;
        }

        public objectModel RotateXY(objectModel model, double angle)
        {
            angle = angle * Math.PI / 180;
            objectModel result = model;
            double[,] turnMatrix = new double[3, 3];
            turnMatrix[0,0] = Math.Cos(angle);
            turnMatrix[0,1] = -Math.Sin(angle);
            turnMatrix[0,2] = 0;
            turnMatrix[1,0] = Math.Sin(angle);
            turnMatrix[1,1] = Math.Cos(angle);
            turnMatrix[1,2] = 0;
            turnMatrix[2,0] = 0;
            turnMatrix[2,1] = 0;
            turnMatrix[2,2] = 1;

            result = modelLinearTransformation(model, turnMatrix);
            return result;
        }
        public objectModel objectMove(objectModel model, double x, double y, double z) 
        { 
            objectModel result = model;
            for (int i = 0; i < model.mesh.Length; i++)
            {
                for (int j = 0; j < model.mesh[i].points.Length; j++)
                {
                    result.mesh[i].points[j].x = model.mesh[i].points[j].x + x;
                    result.mesh[i].points[j].y = model.mesh[i].points[j].y + y;
                    result.mesh[i].points[j].z = model.mesh[i].points[j].z + z;
                }
            }
            return result; 
        }
        public objectModel objectScale(objectModel model, double scale)
        {
            objectModel result = model;

            double[,] scaleMatrix = new double[3, 3];
            scaleMatrix[0, 0] = scale;
            scaleMatrix[0, 1] = 0;
            scaleMatrix[0, 2] = 0;
            scaleMatrix[1, 0] = 0;
            scaleMatrix[1, 1] = scale;
            scaleMatrix[1, 2] = 0;
            scaleMatrix[2, 0] = 0;
            scaleMatrix[2, 1] = 0;
            scaleMatrix[2, 2] = scale;

            result = modelLinearTransformation(model, scaleMatrix);
            return result;
        }
    }
}

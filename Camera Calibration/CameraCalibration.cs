using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MathNet.Numerics.LinearAlgebra;

namespace CameraCalibration
{
    public class CameraCalibration
    {
        public static PointF ImageToWorld(double[] imagePoint ,
                                          double[,] intrinsicMatrix,
                                          double[,] rotationMatrix,
                                          double[] translationVector)
        {
            var iP = Matrix<double>.Build.DenseOfRowArrays(imagePoint);
            var iM = Matrix<double>.Build.DenseOfArray(intrinsicMatrix);
            var rM = Matrix<double>.Build.DenseOfArray(rotationMatrix);
            var tV = Vector<double>.Build.DenseOfArray(translationVector);

            rM =  rM.SubMatrix(0, 2, 0, 3);
            var tForm = rM.InsertRow(3,tV).Multiply(iM);
            var result = iP.Multiply(tForm.Inverse());

            PointF worldPoint = default;
            worldPoint.X = (float)(result[0, 0] / result[2, 0]);
            worldPoint.Y = (float)(result[1, 0] / result[2, 0]);
            return worldPoint;
        }
    }
}
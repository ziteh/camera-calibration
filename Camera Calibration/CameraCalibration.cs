using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using MathNet.Numerics.LinearAlgebra;

namespace CameraCalibration
{
    public class CameraCalibration
    {
        public static double[] ImageToWorld(double[] imagePoint,
                                          double[,] intrinsicMatrix,
                                          double[,] rotationMatrix,
                                          double[] translationVector)
        {
            var iP = Matrix<double>.Build.DenseOfRowArrays(imagePoint);
            var iM = Matrix<double>.Build.DenseOfArray(intrinsicMatrix);
            var rM = Matrix<double>.Build.DenseOfArray(rotationMatrix);
            var tV = Vector<double>.Build.DenseOfArray(translationVector);

            iP = iP.InsertColumn(2, Vector<double>.Build.DenseOfArray(new double[] { 1 }));
            rM = rM.SubMatrix(0, 2, 0, 3);
            var tForm = rM.InsertRow(2, tV).Multiply(iM);
            var result = iP.Multiply(tForm.Inverse());

            return new double[] 
            {
                (result[0, 0] / result[0, 2]),
                (result[0, 1] / result[0, 2])
            };
        }
    }
}
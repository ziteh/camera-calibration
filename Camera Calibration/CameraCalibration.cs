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
            var iP = Vector<double>.Build.DenseOfArray(imagePoint);
            var iM = Matrix<double>.Build.DenseOfArray(intrinsicMatrix);
            var rM = Matrix<double>.Build.DenseOfArray(rotationMatrix);
            var tV = Vector<double>.Build.DenseOfArray(translationVector);
        }
    }
}
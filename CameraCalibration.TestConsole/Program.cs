using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CameraCalibration;

namespace CameraCalibration.TestConsole
{
    internal class Program
    {
        private static double[,] iM = new double[,]
        {
            { 1072.82150908417, 0, 0 },
            { -2.67264859598147, 1072.75394896968, 0 },
            { 665.983806358150, 398.397867569891, 1 }
        };

        private static double[,] rM = new double[,]
        {
            { 0.9966, 0.0166, -0.0809 },
            { -0.0248, 0.9946, -0.1011 },
            { 0.0788, 0.1028, 0.9916 }
        };

        private static double[] tV = new double[]
            { -114.516132852586, -81.6117343486005, 385.812352338441 };

        private static void Main(string[] args)
        {
            Console.Write("Input Pixel-X: ");
            var pixelX = Convert.ToDouble(Console.ReadLine());

            Console.Write("Input Pixel-Y: ");
            var pixelY = Convert.ToDouble(Console.ReadLine());

            var pixelPoint = new double[] { pixelX, pixelY };
            var worldPoint = CameraCalibration.ImageToWorld(pixelPoint, iM, rM, tV);
            Console.WriteLine($"World: {worldPoint.X} , {worldPoint.Y}");

            Console.WriteLine("\r\n\r\nPress Enter To Exit ...");
            Console.ReadLine();
        }
    }
}
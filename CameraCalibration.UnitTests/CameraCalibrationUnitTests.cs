using System;
using NUnit.Framework;

namespace CameraCalibration.UnitTests
{
    [TestFixture]
    public class CameraCalibrationUnitTests
    {
        [Test]
        public void ImageToWorld_InputRealData_OutputRealData()
        {
            // Arrange.
            const int allowableError = 1;

            // Act.
            var actual = CameraCalibration.ImageToWorld(_imagePoint,
                                                        _intrinsicMatrix,
                                                        _rotationMatrix,
                                                        _translationVector);

            // Assert.
            var errorX = Math.Abs(actual[0] - _worldPoint[0]);
            var errorY = Math.Abs(actual[1] - _worldPoint[1]);
            
            Assert.IsTrue(errorX < allowableError);
            Assert.IsTrue(errorY < allowableError);
        }

        private static double[,] _intrinsicMatrix =
        {
            { 1072.82150908417, 0, 0 },
            { -2.67264859598147, 1072.75394896968, 0 },
            { 665.983806358150, 398.397867569891, 1 }
        };

        private static double[,] _rotationMatrix =
        {
            { 0.9966, 0.0166, -0.0809 },
            { -0.0248, 0.9946, -0.1011 },
            { 0.0788, 0.1028, 0.9916 }
        };

        private static double[] _translationVector =
            { -114.516132852586, -81.6117343486005, 385.812352338441 };

        private static double[] _worldPoint = { 0, 125, 0 };

        private static double[] _imagePoint = { 329.1558535, 521.2226187 };
    }
}
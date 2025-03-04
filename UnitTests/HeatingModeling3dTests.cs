using Newtonsoft.Json.Linq;
using ROD_Lab1.Services;
using System.Windows.Media.Media3D.Converters;

namespace UnitTests
{
    public class HeatingModeling3dTests
    {
        [Theory]
        [InlineData(0.1, 0.1, 0.1)]
        [InlineData(0.1, 0.01, 0.1)]
        [InlineData(0.1, 0.1, 0.01)]
        [InlineData(0.5, 0.01, 0.01)]
        public void IsStable_PassCorrectParameters_GetTrue_Test(double h, double tau, double a)
        {
            //(tau * a * a) / (h * h) < 0.125
            // Arrange
            HeatingModelSettings hms = new();
            hms.h = h;
            hms.tau = tau;
            hms.a = a;

            // Act
            bool result = hms.isStable;

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(0.01, 0.5, 0.01)]
        [InlineData(0.01, 0.1, 0.1)]
        [InlineData(0.01, 0.01, 0.5)]
        public void IsStable_PassIncorrectParameters_GetFalse_Test(double h, double tau, double a)
        {
            // Arrange
            HeatingModelSettings hms = new();
            hms.h = h;
            hms.tau = tau;
            hms.a = a;

            // Act
            bool result = hms.isStable;

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void HeatingModeling_PassCorrectModel_GetTrue_Test()
        {
            // Arrange
            HeatingModeling3d hm = new();
            HeatingModelSettings hms = new();
            hm.SolveParallel(hms);
            hms = hm.st;

            // Act
            int i = hms.iSize / 2;
            int j = hms.jSize / 2;
            int k = hms.kSize / 2;
            bool result = true;
            result &= hms.u[i][j][k] < hms.u[0][j][k];
            result &= hms.u[i][j][k] < hms.u[i][0][k];
            result &= hms.u[i][j][k] < hms.u[i][j][0];

            // Assert
            Assert.True(result);
        }    
    }
}
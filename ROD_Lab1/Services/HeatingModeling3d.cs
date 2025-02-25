using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROD_Lab1.Services
{
    public struct HeatingModelSettings
    {
        #region Границы
        // Границы задаются линейной функцией от двух аргументов - двух координат.
        // При желании можно занулить веса для координат и получится граница заданная константой
        public double A_i_weight = 1;   // Граница А, вес для координаты i
        public double A_j_weight = 2;   // Граница А, вес для координаты j
        public double A_free_weight = 3;// Граница А, свободный член
        // AA - границы в тех же координатах, что и А, только на другой стороне куба
        public double AA_i_weight = 4;  
        public double AA_j_weight = 5;
        public double AA_free_weight = 6;

        public double B_k_weight = 7;
        public double B_j_weight = 8;
        public double B_free_weight = 9;

        public double BB_k_weight = 10;
        public double BB_j_weight = 11;
        public double BB_free_weight = 12;

        public double C_i_weight = 13;
        public double C_k_weight = 14;
        public double C_free_weight = 15;

        public double CC_i_weight = 16;
        public double CC_k_weight = 17;
        public double CC_free_weight = 18;
        #endregion

        // Размеры параллелепипеда в см
        public double iActualSize = 10;
        public double jActualSize = 10;
        public double kActualSize = 10;

        // Шаги и коэффициент
        public double h = 0.01;
        public double tau = 0.01;
        public double a = 0.03;

        public double initTime = 0;
        public double maxTime;

        // Условие устойчивости
        public bool isStable => (tau * a * a) / (h * h) < 0.125;

        // Массивы температур
        public double[][][] u;
        public double[][][] uNew;

        // размеры массивов
        public int iSize => (int)(iActualSize / h);
        public int jSize => (int)(jActualSize / h);
        public int kSize => (int)(kActualSize / h);

        public HeatingModelSettings()
        {
            InitializeU();
        }

        private void InitializeU()
        {
            double[][][] uTemp = new double[iSize][][];
            int iSizeVar = iSize;
            int jSizeVar = jSize;
            int kSizeVar = kSize;

            Parallel.For(0, iSizeVar, i =>
            {
                uTemp[i] = new double[jSizeVar][];
                for (int j = 0; j < jSizeVar; j++)
                {
                    uTemp[i][j] = new double[kSizeVar];
                    for (int k = 0; k < kSizeVar; k++)
                    {
                        uTemp[i][j][k] = 0;
                    }
                }
            });
            uNew = u = uTemp;
        }
    }
    public class HeatingModeling3d
    {
    }
}

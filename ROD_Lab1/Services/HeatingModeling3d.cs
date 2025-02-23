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
        public double A_i_weight = 0;   // Граница А, вес для координаты i
        public double A_j_weight = 0;   // Граница А, вес для координаты j
        public double A_free_weight = 0;// Граница А, свободный член
        // AA - границы в тех же координатах, что и А, только на другой стороне куба
        public double AA_i_weight = 0;  
        public double AA_j_weight = 0;
        public double AA_free_weight = 0;

        public double B_j_weight = 0;
        public double B_k_weight = 0;
        public double B_free_weight = 0;

        public double BB_j_weight = 0;
        public double BB_k_weight = 0;
        public double BB_free_weight = 0;

        public double C_i_weight = 0;
        public double C_k_weight = 0;
        public double C_free_weight = 0;

        public double CC_i_weight = 0;
        public double CC_k_weight = 0;
        public double CC_free_weight = 0;
        #endregion

        // Размеры параллелепипеда в см
        public double iActualSize = 100;
        public double jActualSize = 100;
        public double kActualSize = 100;

        // Шаги и коэффициент
        public double h = 0.01;
        public double tau = 0.01;
        public double a = 0.03;

        // Условие устойчивости
        public bool isStable => (tau * a * a) / (h * h) < 0.125;

        // Массивы температур
        public double[,,] u;
        public double[,,] uNew;

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
            u = new double[iSize,jSize,kSize];
            for (int i = 0; i < iSize; i++)
                for (int j = 0; j < jSize; j++)
                    for (int k = 0; k < kSize; k++)
                    {
                        u[i, j, k] = 0;
                    }
            uNew = u;
        }
    }
    public class HeatingModeling3d
    {
    }
}

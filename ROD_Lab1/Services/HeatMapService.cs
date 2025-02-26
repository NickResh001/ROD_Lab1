using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows;

namespace ROD_Lab1.Services
{
    public class HeatMapService
    {
        private double min, max;
        private int sliderCount;
        public HeatMapService(double min, double max, int sliderCount) 
        {
            this.min = min;
            this.max = max;
            this.sliderCount = sliderCount;
        }

        private byte GetRed(double uValue)
        {
            return (byte)((255 * uValue) / (max - min));
        }
        public WriteableBitmap CreateBitmap(double[][] uProj, int jSize, int kSize)
        {
            byte[] pixels = new byte[jSize * kSize * 3];
            WriteableBitmap bitmap = new(kSize, jSize, 96, 96, PixelFormats.Rgb24, null);
            for (int j = 0; j < jSize; j++)
            {
                for (int k = 0; k < kSize; k++)
                {
                    int index = (j * kSize + k) * 3;
                    byte r = GetRed(uProj[j][k]);
                    pixels[index + 0] = r;                  //R
                    pixels[index + 1] = (byte)(255 - r);    //G
                    pixels[index + 2] = 0;                  //B
                }
            }
            Int32Rect rect = new Int32Rect(0, 0, kSize, jSize);
            bitmap.WritePixels(rect, pixels, kSize * 3, 0);

            return bitmap;
        }
        public WriteableBitmap[] CreateHeatMap(double[][][] u, int iSize, int jSize, int kSize)
        {
            WriteableBitmap[] result = new WriteableBitmap[sliderCount];
            int offset = (int)(iSize / sliderCount);
            for (int i = 0; i < iSize; i++)
            {
                if ((i + 1) % offset != 0) 
                    continue;

                int index = (i + 1) / offset - 1;
                for (int j = 0; j < jSize; j++)
                {
                    for (int k = 0; k < kSize; k++)
                    {
                        result[index] = CreateBitmap(u[i], jSize, kSize);
                    }
                }
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LAB1
{
    class BMPEditorcs
    {
        Bitmap image;
        string imagePath;

        public BMPEditorcs(string path)
        {
            imagePath = path;
                image = new(path);
        }

        public void BWFilter()
        {
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    byte R = image.GetPixel(i, j).R;
                    byte G = image.GetPixel(i, j).G;
                    byte B = image.GetPixel(i, j).B;
                    byte Depth = Convert.ToByte((R + G + B) / 3);
                    Color cvet = Color.FromArgb(0, Depth, Depth, Depth);
                    image.SetPixel(i, j, cvet);
                }
            }
            
        }
        public void Save()
        {
            image.Save(imagePath + "_new.bmp");
        }

        public void Frame(UInt16 Thickness)
        {
            Random rnd = new();
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    if (i < Thickness || i > (image.Width - Thickness) || j < Thickness || j > (image.Height - Thickness))
                    {
                        byte R = Convert.ToByte(rnd.Next(0, 255));
                        byte G = Convert.ToByte(rnd.Next(0, 255));
                        byte B = Convert.ToByte(rnd.Next(0, 255));
                        Color cvet = Color.FromArgb(0, R, G, B);
                        image.SetPixel(i, j, cvet);
                    }
                }
            }
        }

        public void Close()
        {
            image.Dispose();
        }

        public void Info()
        {
            BMPInfo.ReadHeader(imagePath);
            BMPInfo.ShowHeader();
        }
        //"D:\\GIT_MAIN\\PresentationGraphInfo\\_сarib_TC.bmp"
    }
}

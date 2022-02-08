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
        Bitmap bmp90;
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

        public void Turn90()
        {
            Bitmap bmp90 = new(image.Height, image.Width);
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    bmp90.SetPixel((image.Height - j - 1), i, (image.GetPixel(i, j)));
                }
            }
            bmp90.Save(imagePath+"_90.bmp");
        }

        public void OpenImage()
        {
            Bitmap bmp_16 = new("D:\\GIT_MAIN\\PresentationGraphInfo\\CAT16.bmp");
            Bitmap bmp_256_color = new("D:\\GIT_MAIN\\PresentationGraphInfo\\CAT256.bmp");
            Bitmap bmp_TC = new("D:\\GIT_MAIN\\PresentationGraphInfo\\_сarib_TC.bmp");

            /* for (int i = 0; i < image.Width; i++)
             {
                 for (int j = 0; j < image.Height; j++)
                 {
                     byte R = Convert.ToByte(bmp_16.GetPixel(i, j).R);
                     byte G = Convert.ToByte(bmp_16.GetPixel(i, j).G);
                     byte B = Convert.ToByte(bmp_16.GetPixel(i, j).B);
                     Color cvet = Color.FromArgb(0, R, G, B);
                     bmp_16.SetPixel(i, j, cvet);
                 }
             }

             bmp_16.Save(imagePath + "_16.bmp");
            */
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    byte Alpha = Convert.ToByte(bmp_256_color.GetPixel(i, j).A);
                    byte R = Convert.ToByte(bmp_256_color.GetPixel(i, j).R);
                    byte G = Convert.ToByte(bmp_256_color.GetPixel(i, j).G);
                    byte B = Convert.ToByte(bmp_256_color.GetPixel(i, j).B);
                    Color cvet = Color.FromArgb(0, R, G, B);
                    bmp_256_color.SetPixel(i, j, cvet);
                }
            }

            bmp_256_color.Save("D:\\GIT_MAIN\\PresentationGraphInfo\\bmp_256_color.bmp");

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    byte Alpha = Convert.ToByte(bmp_TC.GetPixel(i, j).A);
                    byte R = Convert.ToByte(bmp_TC.GetPixel(i, j).R);
                    byte G = Convert.ToByte(bmp_TC.GetPixel(i, j).G);
                    byte B = Convert.ToByte(bmp_TC.GetPixel(i, j).B);
                    Color cvet = Color.FromArgb(Alpha, R, G, B);
                    bmp_TC.SetPixel(i, j, cvet);
                }
            }

            bmp_TC.Save("D:\\GIT_MAIN\\PresentationGraphInfo\\NIGGA.bmp");

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

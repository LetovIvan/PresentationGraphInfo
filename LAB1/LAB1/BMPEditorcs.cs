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

        public void OpenImage(int Task)
        {
            if (Task == 1)
            {
                Bitmap bmp_16 = new("D:\\GIT_MAIN\\PresentationGraphInfo\\CAT16.bmp");
                Bitmap temp = new(bmp_16.Width, bmp_16.Height);
                for (int i = 0; i < bmp_16.Width; i++)
                {
                    for (int j = 0; j < bmp_16.Height; j++)
                    {
                        byte A = Convert.ToByte(bmp_16.GetPixel(i, j).A);
                        byte R = Convert.ToByte(bmp_16.GetPixel(i, j).R);
                        byte G = Convert.ToByte(bmp_16.GetPixel(i, j).G);
                        byte B = Convert.ToByte(bmp_16.GetPixel(i, j).B);
                        Color cvet = Color.FromArgb(A, R, G, B);
                        temp.SetPixel(i, j, cvet);
                    }
                }
                temp.Save("D:\\GIT_MAIN\\PresentationGraphInfo\\CAT16_new.bmp");
            }

            else if (Task == 2)
            {
                Bitmap bmp_256_color = new("D:\\GIT_MAIN\\PresentationGraphInfo\\CAT256.bmp");
                Bitmap temp = new(bmp_256_color.Width, bmp_256_color.Height);
                for (int i = 0; i < bmp_256_color.Width; i++)
                {
                    for (int j = 0; j < bmp_256_color.Height; j++)
                    {
                        byte A = Convert.ToByte(bmp_256_color.GetPixel(i, j).A);
                        byte R = Convert.ToByte(bmp_256_color.GetPixel(i, j).R);
                        byte G = Convert.ToByte(bmp_256_color.GetPixel(i, j).G);
                        byte B = Convert.ToByte(bmp_256_color.GetPixel(i, j).B);
                        Color cvet = Color.FromArgb(A, R, G, B);
                        temp.SetPixel(i, j, cvet);
                    }
                }
                temp.Save("D:\\GIT_MAIN\\PresentationGraphInfo\\CAT256_color.bmp");
            }

            else if (Task == 3)
            {
                Bitmap bmp_TC = new("D:\\GIT_MAIN\\PresentationGraphInfo\\_сarib_TC.bmp");
                Bitmap temp = new(bmp_TC.Width, bmp_TC.Height);
                for (int i = 0; i < bmp_TC.Width; i++)
                {
                    for (int j = 0; j < bmp_TC.Height; j++)
                    {
                        byte A = Convert.ToByte(bmp_TC.GetPixel(i, j).A);
                        byte R = Convert.ToByte(bmp_TC.GetPixel(i, j).R);
                        byte G = Convert.ToByte(bmp_TC.GetPixel(i, j).G);
                        byte B = Convert.ToByte(bmp_TC.GetPixel(i, j).B);
                        Color cvet = Color.FromArgb(A, R, G, B);
                        temp.SetPixel(i, j, cvet);
                    }
                }
                temp.Save("D:\\GIT_MAIN\\PresentationGraphInfo\\_сarib_TC_color.bmp");
            }
            else
                Console.WriteLine("uncorect Task!");

        }

        public void Scaler(int Scale)
        {
            Bitmap bmp_256_color = new("D:\\GIT_MAIN\\PresentationGraphInfo\\CAT256.bmp");
            
            int Width = bmp_256_color.Width * Scale;
            int Height = bmp_256_color.Height * Scale;
            Bitmap temp = new(Width, Height);
            for (int i = 0; i < Width; i+= Scale)
            {
                for (int j = 0; j < Height; j+= Scale)
                {
                    byte A = Convert.ToByte(bmp_256_color.GetPixel(i / Scale, j / Scale).A);
                    byte R = Convert.ToByte(bmp_256_color.GetPixel(i / Scale, j / Scale).R);
                    byte G = Convert.ToByte(bmp_256_color.GetPixel(i / Scale, j / Scale).G);
                    byte B = Convert.ToByte(bmp_256_color.GetPixel(i / Scale, j / Scale).B);
                    Color cvet = Color.FromArgb(A, R, G, B);
                    for (int S = 0; S < Scale; S++)
                    { 
                        temp.SetPixel(i + S, j, cvet);
                        temp.SetPixel(i, j + S, cvet);
                    }
                }
            }
            temp.Save("D:\\GIT_MAIN\\PresentationGraphInfo\\CAT256_color.bmp");
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
    }
}
        //"D:\\GIT_MAIN\\PresentationGraphInfo\\_сarib_TC.bmp"

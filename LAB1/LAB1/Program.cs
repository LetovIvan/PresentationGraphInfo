﻿using System;
using System.Drawing;

namespace LAB1
{
    public class Program
    {
        static void Main()
        {
            BMPEditorcs bmpEditorcs = new("D:\\GIT_MAIN\\PresentationGraphInfo\\_сarib_TC.bmp");
            //bmpEditorcs.BWFilter();
            //bmpEditorcs.Frame(15);
            //bmpEditorcs.Turn90();
            //bmpEditorcs.Save();
            //bmpEditorcs.OpenImage(3);
            bmpEditorcs.Scaler(2);
            bmpEditorcs.Close();
            //bmpEditorcs.Info();
        }
    }
}

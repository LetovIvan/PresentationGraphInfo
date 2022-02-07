using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1
{
    class BMPInfo
    {
        static UInt16 file_type = 0x4D42;    //Тип файла 0x4D42
        static UInt32 file_size = 0; //Размер файла
        static UInt16 reserved1 = 0;
        static UInt16 reserved2 = 0;
        static UInt32 offset_data = 0;   //Позиция пикселей в файле
        static UInt32 size = 0;    //Размер заголовка
        static Int32 width = 0;
        static Int32 height = 0;
        static UInt16 planes = 1;
        static UInt16 bit_count = 0;
        static UInt32 compression = 0; //Сжатие 0-3
        static UInt32 size_image = 0;  //0 - для несжатых изображений
        static Int32 x_pixels_per_meter = 0;
        static Int32 y_pixels_per_meter = 0;
        static UInt32 colors_used = 0;
        static UInt32 colors_important = 0;

        public static void ReadHeader(string imagePath)
        {
            FileStream fileStream = new(imagePath, FileMode.Open);
            BinaryReader otherImage = new(fileStream);
            //
            file_type = otherImage.ReadUInt16();
            file_size = otherImage.ReadUInt32();
            reserved1 = otherImage.ReadUInt16();
            reserved2 = otherImage.ReadUInt16();
            offset_data = otherImage.ReadUInt32();
            size = otherImage.ReadUInt32();
            width = otherImage.ReadInt32();
            height = otherImage.ReadInt32();
            planes = otherImage.ReadUInt16();
            bit_count = otherImage.ReadUInt16();
            compression = otherImage.ReadUInt32();
            size_image = otherImage.ReadUInt32();
            x_pixels_per_meter = otherImage.ReadInt32();
            y_pixels_per_meter = otherImage.ReadInt32();
            colors_used = otherImage.ReadUInt32();
            colors_important = otherImage.ReadUInt32();
        }

        public static void ShowHeader()
        {
            Console.WriteLine("file_type: {0}", file_type);
            Console.WriteLine("file_size: {0}", file_size);
            Console.WriteLine("reserved1: {0}", reserved1);
            Console.WriteLine("reserved2: {0}", reserved2);
            Console.WriteLine("offset_data: {0}", offset_data);
            Console.WriteLine();
            Console.WriteLine("size: {0}", size);
            Console.WriteLine("width: {0}", width);
            Console.WriteLine("height: {0}", height);
            Console.WriteLine("planes: {0}", planes);
            Console.WriteLine("bit_count: {0}", bit_count);
            Console.WriteLine("compression: {0}", compression);
            Console.WriteLine("size_image: {0}", size_image);
            Console.WriteLine("x_pixels_per_meter: {0}", x_pixels_per_meter);
            Console.WriteLine("y_pixels_per_meter: {0}", y_pixels_per_meter);
            Console.WriteLine("colors_used: {0}", colors_used);
            Console.WriteLine("colors_important: {0}", colors_important);
            Console.ReadKey();
        }
    }
}    

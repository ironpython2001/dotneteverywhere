using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace InstantOpenCV
{
    public class ImgToRawBytes
    {
        public static void Run()
        {
            Mat image2 = new Mat(480, 640,MatType.CV_8UC3);
            Console.WriteLine(image2.Rows.ToString());
            image2.ImWrite("testimg.png");
            
        }
    }
}

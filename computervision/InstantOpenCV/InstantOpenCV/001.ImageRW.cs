using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace InstantOpenCV
{
    public class ImageRW
    {
        public static void Run()
        {
            var image = Cv2.ImRead("lenna.png");
            image.ImWrite("lenna.jpg");

            var grayImage = Cv2.ImRead("lenna.png", ImreadModes.GrayScale);
            grayImage.ImWrite("lennagray.jpg");
            
        }
    }
}

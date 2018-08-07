using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;


namespace InstantOpenCV
{
    class Program
    {
        static void Main(string[] args)
        {
            //Mat src = new Mat("lenna.png", ImreadModes.GrayScale);
            //// Mat src = Cv2.ImRead("lenna.png", ImreadModes.GrayScale);
            //Mat dst = new Mat();

            //Cv2.Canny(src, dst, 50, 200);
            //using (new Window("src image", src))

            //using (var wnd=new Window("dst image", dst))
            //{
            //    wnd.Resize(1000, 1000);
            //    Cv2.WaitKey();
            //}
            //ImageRW.Run();
            ImgToRawBytes.Run();
                
        }
    }
}

using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeFilter
{
    class Program
    {
        static void Test(string[] args)
        {
            VideoCapture capture = new VideoCapture(0);

            Mat capturedImg = capture.QueryFrame();

            capturedImg.Save("Original.jpg");

            EdgeFilter.UseAverage = false;
            EdgeFilter.Threshold = .9;
            EdgeFilter.Smooth = true;
            EdgeFilter.OutOfBoundMask = 10;
            EdgeFilter.FilterImage(capturedImg);
            
            Console.ReadKey();
        }
    }
}

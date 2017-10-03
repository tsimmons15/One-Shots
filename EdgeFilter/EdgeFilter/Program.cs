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
        static void Main(string[] args)
        {
            VideoCapture capture = new VideoCapture(0);

            Mat capturedImg = capture.QueryFrame();

            capturedImg.Save("C:\\Users\\student-eac\\Desktop\\img.jpg");

            EdgeFilter.UseAverage = false;
            EdgeFilter.Threshold = .9;
            EdgeFilter.FilterImage(capturedImg);
            Console.ReadKey();
        }
    }
}

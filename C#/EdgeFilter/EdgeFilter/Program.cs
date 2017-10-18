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
            PastelTest();
        }

        static void PastelTest()
        {
            VideoCapture capture = new VideoCapture(0);

            Mat capturedImg;


            for (double i = .1; i < 5; i += .1)
            {

                capturedImg = capture.QueryFrame();

                capturedImg.Save("Original-" + i + ".jpg");
            

                EdgeFilter.UseAverage = false;
                EdgeFilter.Threshold = i;
                EdgeFilter.Smooth = true;
                EdgeFilter.OutOfBoundMask = 10;

                Console.WriteLine("Testing with threshold " + i);
                EdgeFilter.PastelFilterImage(capturedImg);
            }
            Console.ReadKey();
        }
    }
}

using Emgu.CV;
using Emgu.CV.Structure;
using System;

namespace EdgeFilter
{
    class EdgeFilter
    {

        private static int cellSize = 0;
        public static int CellSize
        {
            get
            {
                return cellSize;
            }

            set
            {
                if (value % 5 == 0)
                    cellSize = value;
            }
        }

        public static int VerticalCells
        {
            get
            {
                return OriginalImage.Rows / CellSize;
            }
        }

        public static int HorizontalCells
        {
            get
            {
                return 0;
            }
        }

        public static byte OutOfBoundMask
        {
            get; set;
        }

        public static Image<Gray, Byte> OriginalImage
        {
            get; set;
        }

        public static Image<Gray, Byte> FilteredImage
        {
            get; set;
        }

        public static void FilterImage(Mat img)
        {
            FilterImage(img.ToImage<Gray, Byte>());
        }

        public static void FilterImage(Image<Gray, Byte> img)
        {
            for(int i = 0; i < VerticalCells; i++)
            {
                for(int j = 0; j < HorizontalCells; j++)
                {

                }
            }
        }
    }
}

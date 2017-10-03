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

        private static byte outOfBoundMask = 0;
        public static byte OutOfBoundMask
        {
            get
            {
                return outOfBoundMask;
            }

            set
            {
                outOfBoundMask = value;
            }
        }

        public static Image<Gray, Byte> OriginalImage
        {
            get; set;
        }

        public static Image<Gray, Byte> FilteredImage
        {
            get; set;
        }

        public static Boolean UseAverage
        {
            get; set;
        }

        public static double Threshold
        {
            get; set;
        }

        public static Boolean Smooth
        {
            get;
            set;
        }

        public static void FilterImage(Mat img)
        {
            OriginalImage = img.ToImage<Gray, Byte>();
            FilteredImage = img.ToImage<Gray, Byte>();
            Filter();
        }

        private static byte average = 0;
        private static byte max = 0;
        private static byte min = 0;
        private static void findMinMax(int row, int col)
        {
            int vStart = 0, vEnd = 0, hStart = 0, hEnd = 0;

            vStart = row - 2;
            vEnd = row + 2;

            hStart = col - 2;
            hEnd = col + 2;

            if (OutOfBoundMask == 0)
            {
                if (row < 2)
                    vStart = 0;
                
                if (row > OriginalImage.Rows)
                    vEnd = OriginalImage.Rows;

                if (col < 2)
                    hStart = 0;

                if (col > OriginalImage.Cols)
                    hEnd = OriginalImage.Cols;
            }
            
            for (int i = vStart; i < vEnd; i++)
            {
                for (int j = hStart; j < hEnd; j++)
                {
                    byte value = 0;
                    if (i < 0 || j < 0 || i >= OriginalImage.Rows || j >= OriginalImage.Cols)
                    {
                        value = OutOfBoundMask;
                    }
                    else
                    {
                        value = OriginalImage.Data[i, j, 0];
                    }

                    if (min > value)
                        min = value;
                    if (max < value)
                       max = value;
                }
            }
        }

        private static void findAverage(int row, int col)
        {
            int vStart = 0, vEnd = 0, hStart = 0, hEnd = 0;

            vStart = row - 2;
            vEnd = row + 2;

            hStart = col - 2;
            hEnd = col + 2;

            if (OutOfBoundMask == 0)
            {
                if (row < 2)
                    vStart = 0;

                if (row > OriginalImage.Rows)
                    vEnd = OriginalImage.Rows;

                if (col < 2)
                    hStart = 0;

                if (col > OriginalImage.Cols)
                    hEnd = OriginalImage.Cols;
            }

            byte total = 0;
            for (int i = vStart; i < vEnd; i++)
            {
                for (int j = hStart; j < hEnd; j++)
                {
                    byte value = 0;
                    if (i < 0 || j < 0 || i >= OriginalImage.Rows || j >= OriginalImage.Cols)
                    {
                        value = OutOfBoundMask;
                    }
                    else
                    {
                        value = OriginalImage.Data[i, j, 0];
                    }
                    
                    total += value;
                }
            }
            average = (byte)(total / ((vEnd - vStart) * (hEnd - hStart)));
        }

        public static void FilterImage(Image<Gray, Byte> img)
        {
            OriginalImage = img;
            FilteredImage = img;
            Filter();
        }

        public static void Filter()
        {
            Console.WriteLine("Begin filtering...\n");
            byte value = 0;
            byte threshold = 0;
            for (int i = 0; i < OriginalImage.Rows; i++)
            {
                for (int j = 0; j < OriginalImage.Cols; j++)
                {
                    if (UseAverage)
                    {
                        findAverage(i, j);
                        value = average;
                    }
                    else
                    {
                        findMinMax(i, j);
                        value = (byte)(max - min);
                        max = 0;
                        min = 0;
                    }
                    threshold = (byte)(value * Threshold);
                    FilteredImage.Data[i, j, 0] = (byte)((OriginalImage.Data[i, j, 0] < threshold) ? 255 : 0);
                }
            }
            FilteredImage.Save("Filtered.jpg");
            Console.WriteLine("End filtering...\n");

            CvInvoke.PyrUp(FilteredImage, FilteredImage, Emgu.CV.CvEnum.BorderType.Default);
            CvInvoke.PyrDown(FilteredImage, FilteredImage, Emgu.CV.CvEnum.BorderType.Default);

            Console.WriteLine("End smoothing...\n");

            FilteredImage.Save("Smoothed.jpg");
        }
    }
}

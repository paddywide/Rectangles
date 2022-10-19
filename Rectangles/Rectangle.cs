using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangles
{
    public class Rectangle
    {
        //TopLeftX and TopLeftY are the coordiantes, it starts with 0
        public int TopLeftX { get; private set; }
        public int TopLeftY { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Rectangle(int topLeftX, int topLeftY, int width, int height)
        {
            if (topLeftX < Constant.MinTopLeft || topLeftX > Constant.MaxTopLeftX)
                throw new ArgumentOutOfRangeException("Rectangle top left X coordinate must be range from 0 to 23.");

            if (topLeftY < Constant.MinTopLeft || topLeftY > Constant.MaxTopLeftY)
                throw new ArgumentOutOfRangeException("Rectangle top left Y coordinate must be range from 0 to 23.");

            if (width < Constant.MinRectangleLength || width > Constant.MaxRectangleLength)
                throw new ArgumentOutOfRangeException("Rectangle width must be range from 1 to 25.");

            if (height < Constant.MinRectangleLength || height > Constant.MaxRectangleLength)
                throw new ArgumentOutOfRangeException("Rectangle height must be range from 1 to 25.");

            TopLeftX = topLeftX;
            TopLeftY = topLeftY;
            Width = width;
            Height = height;
        }


    }
}

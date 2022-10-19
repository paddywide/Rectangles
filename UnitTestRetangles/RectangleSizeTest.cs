using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rectangles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestRetangles
{
    [TestClass]
    public class RectangleSizeTest
    {
        [TestMethod, TestCategory("UnitTest")]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Rectangle top left X coordinate must be range from 0 to 23.")]
        public void Rectangle_OutOfRange_TopLeftX_Over()
        {
            Rectangle rectangle = new Rectangle(24, 10, 3, 5);
        }

        [TestMethod, TestCategory("UnitTest")]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Rectangle top left X coordinate must be range from 0 to 23.")]
        public void Rectangle_OutOfRange_TopLeftX_Below()
        {
            Rectangle rectangle = new Rectangle(-10, 10, 3, 5);
        }

        [TestMethod, TestCategory("UnitTest")]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Rectangle top left X coordinate must be range from 0 to 23.")]
        public void Rectangle_OutOfRange_TopLeftY_Over()
        {
            Rectangle rectangle = new Rectangle(7, 66, 3, 5);
        }

        [TestMethod, TestCategory("UnitTest")]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Rectangle top left X coordinate must be range from 0 to 23.")]
        public void Rectangle_OutOfRange_TopLeftY_Below()
        {
            Rectangle rectangle = new Rectangle(7, -20, 3, 5);
        }

        [TestMethod, TestCategory("UnitTest")]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Rectangle top left X coordinate must be range from 0 to 23.")]
        public void Rectangle_OutOfRange_Width_Over()
        {
            Rectangle rectangle = new Rectangle(7, 12, 70, 5);
        }

        [TestMethod, TestCategory("UnitTest")]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Rectangle top left X coordinate must be range from 0 to 23.")]
        public void Rectangle_OutOfRange_Width_Below()
        {
            Rectangle rectangle = new Rectangle(7, 12, -5, 5);
        }

        [TestMethod, TestCategory("UnitTest")]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Rectangle top left X coordinate must be range from 0 to 23.")]
        public void Rectangle_OutOfRange_Height_Over()
        {
            Rectangle rectangle = new Rectangle(7, 12, 10, 55);
        }

        [TestMethod, TestCategory("UnitTest")]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Rectangle top left X coordinate must be range from 0 to 23.")]
        public void Rectangle_OutOfRange_Height_Below()
        {
            Rectangle rectangle = new Rectangle(7, 12, 10, -5);
        }

    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rectangles;

namespace RetanglesTests
{
    [TestClass]
    public class GridSizeTest
    {
        [TestMethod, TestCategory("UnitTest")]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Grid width and height must be no less than 5 and no greater than 25.")]
        public void Grid_OutOfRange_X_Over()
        {
            Grid grid = new Grid(30, 12);
        }

        [TestMethod, TestCategory("UnitTest")]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Grid width and height must be no less than 5 and no greater than 25.")]
        public void Grid_OutOfRange_Y_Over()
        {
            Grid grid = new Grid(13, 44);
        }

        [TestMethod, TestCategory("UnitTest")]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Grid width and height must be no less than 5 and no greater than 25.")]
        public void Grid_OutOfRange_X_Below()
        {
            Grid grid = new Grid(-1, 44);
        }

        [TestMethod, TestCategory("UnitTest")]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Grid width and height must be no less than 5 and no greater than 25.")]
        public void Grid_OutOfRange_Y_Below()
        {
            Grid grid = new Grid(16, -33);
        }
    }
}

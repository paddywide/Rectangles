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
    public class RectangleLocationTest
    {
        private Grid grid;
        [TestInitialize]
        public void Setup()
        {
            grid = new Grid(20, 20);
        }

        [TestMethod, TestCategory("UnitTest")]
        public void Rectangle_Extend_Grid()
        {
            Assert.IsFalse(grid.AddRectangle(15, 15, 10, 10));
        }

        [TestMethod, TestCategory("UnitTest")]
        public void Rectangle_Not_Extend_Grid()
        {
            Assert.IsTrue(grid.AddRectangle(5, 7, 10, 10));
        }

        [TestMethod, TestCategory("UnitTest")]
        public void Add_Rectangle_Non_Overlap()
        {
            grid.AddRectangle(5, 5, 10, 10);
            Assert.IsTrue(grid.AddRectangle(3, 3, 1, 1));
        }

        [TestMethod, TestCategory("UnitTest")]
        public void Add_Rectangle_Overlap()
        {
            grid.AddRectangle(5, 5, 10, 10);
            Assert.IsFalse(grid.AddRectangle(2, 7, 4, 4));
        }
    }
}

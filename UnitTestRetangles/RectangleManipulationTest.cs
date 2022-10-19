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
    public class RectangleManipulationTest
    {
        private Grid grid;
        [TestInitialize]
        public void Setup()
        {
            grid = new Grid(20, 20);
        }

        //Add Rectangle
        [TestMethod, TestCategory("UnitTest")]
        public void Grid_Add_Rectangle_Success()
        {
            Assert.IsTrue(grid.AddRectangle(1, 1, 10, 10));
        }

        [TestMethod, TestCategory("UnitTest")]
        public void Grid_Add_Rectangle_Fail()
        {
            Assert.IsFalse(grid.AddRectangle(22, 17, 12, 7));
        }

        //Find Rectangle
        [TestMethod, TestCategory("UnitTest")]
        public void Grid_Find_Rectangle_Success()
        {
            grid.AddRectangle(1, 1, 10, 10);
            Assert.IsTrue(grid.FindRectangleIdx(2, 3) >= 0);
        }

        [TestMethod, TestCategory("UnitTest")]
        public void Grid_Find_Rectangle_Fail()
        {
            grid.AddRectangle(1, 1, 10, 10);
            Assert.IsFalse(grid.FindRectangleIdx(11, 3) < 0);
        }

        //Remove Rectangle
        [TestMethod, TestCategory("UnitTest")]
        public void Grid_Remove_Rectangle_Success()
        {
            grid.AddRectangle(1, 1, 10, 10);
            Assert.IsTrue(grid.RemoveRectangle(2, 3));
        }

        [TestMethod, TestCategory("UnitTest")]
        public void Grid_Remove_Rectangle_Fail()
        {
            grid.AddRectangle(1, 1, 10, 10);
            Assert.IsFalse(grid.RemoveRectangle(12, 3));
        }
    }
}

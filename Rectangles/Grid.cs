using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rectangles
{
    public class Grid
    {
        //X and Y represents the lengh, not the coordinates
        public int X { get; private set; }
        public int Y { get; private set; }
        List<Rectangle> rectangles;

        public Grid(int x, int y)
        {
            if (x < Constant.MinGridLength || x > Constant.MaxGridLength
                || y < Constant.MinGridLength || y > Constant.MaxGridLength)
                throw new ArgumentOutOfRangeException("Grid width and height must be no less than 5 and no greater than 25.");

            X = x;
            Y = y;
            rectangles = new List<Rectangle>();
        }

        public bool AddRectangle(int topLeftX, int topLeftY, int width, int height)
        {
            if (IsOutOfGrid(topLeftX, topLeftY))
                return false;

            if (IsRectangleExtendGrid(topLeftX, topLeftY, width, height))
                return false;

            if (IsOverlapExistingRectangle(topLeftX, topLeftY, width, height))
                return false;

            rectangles.Add(new Rectangle(topLeftX, topLeftY, width, height));

            return true;
        }

        private bool IsOverlapExistingRectangle(int topLeftX, int topLeftY, int width, int height)
        {
            bool found = false;
            foreach (Rectangle existingR in rectangles)
            {
                if (IsInRegctangle(existingR, topLeftX, topLeftY))
                {
                    found = true;
                    break;
                }

                if (IsInRegctangle(existingR, topLeftX + width, topLeftY + height))
                {
                    found = true;
                    break;
                }
            }

            if (found)
                return true;

            return false;
        }

        public int FindRectangleIdx(int findRectangleX, int findRectangleY)
        {
            if (IsOutOfGrid(findRectangleX, findRectangleY))
                return -1;

            int pos;
            bool found = false;
            for (pos = 0; pos < rectangles.Count; pos++)
            {
                if (IsInRegctangle(rectangles[pos], findRectangleX, findRectangleY))
                {
                    found = true;
                    break;
                }
            }

            if (found)
            {
                return pos;
            }

            return -1;
        }
        public bool RemoveRectangle(int findRectangleX, int findRectangleY)
        {
            if (IsOutOfGrid(findRectangleX, findRectangleY))
                return false;

            int index = FindRectangleIdx(findRectangleX, findRectangleY);

            if (index != -1)
            {
                rectangles.RemoveAt(index);
                return true;
            }

            return false;
        }
        public void DisplayGrid()
        {
            /*
            **0 * 1 * 2 * 3 * 4 * 5 * 6 * 7 * 8 * 9 * 10 * 11 * 12 * 13 * 14 * 15 * 16 * 17 * 18 * 19 * ***********
            0 * ***************************************************
            1 * ***************************************************
            2 * ***************************************************
            3 * ***************************************************
            4 * ***************************************************
            5 * **********| -----------------| -*********************
            6 * **********| *****************| **********************
            7 * **********| *****************| **********************
            8 * **********| *****************| **********************
            9 * **********| *****************| **********************
            10 * *********| *****************| ***********************
            11 * *********| *****************| ***********************
            12 * *********| *****************| ***********************
            13 * *********| *****************| ***********************
            14 * *********| _________________ | _ * *********************
            15 * ***************************************************
            16 * ***************************************************
            17 * ***************************************************
            18 * ***************************************************
            19 * ***************************************************

            */
            //each coordinate occupy 2 slot of X. It will not look too tight.
            int xOffset = 2;
            int yOffset = 1;
            int twoDigitOffset = 1;

            int xWidth;
            if (X > 9)
                xWidth = (X - 9) * 1 + 9 * 2;
            else
                xWidth = 9 * 2;

            int xLength = xWidth + xOffset;
            int xCoorLength = X * 2 + xOffset;
            int yLength = Y + yOffset;
            string[,] graph = new string[yLength, xCoorLength];
            //initial the array with space
            for (int y = 0; y <= yLength - 1; y++)
            {
                for (int x = 0; x <= xCoorLength - 1; x++)
                {
                    graph[y, x] = " ";
                }
            }

            //initial X coordinate
            for (int x = xOffset, i = 0; x < xLength; x = (i <= 8) ? x + 2 : x + 1, i++)
            {
                int a = 0;
                if (i == 18)
                    a++;
                graph[0, x] = i.ToString();

            }

            //initial Y coordinate
            for (int y = 1; y <= yLength - 1; y++)
            {
                graph[y, 0] = (((y - 1)).ToString());
            }

            //loop for each retangle and set on the graph
            foreach (Rectangle r in rectangles)
            {
                int xEdgeLen;
                if (r.TopLeftX + r.Width < 10)
                    xEdgeLen = (r.TopLeftX + r.Width) * 2;
                else
                    xEdgeLen = (r.TopLeftX + r.Width - 9) * 1 + 9 * 2;
                //print rectangle top and bottom edge
                for (int edge = r.TopLeftX * 2 + xOffset; edge <= xEdgeLen + xOffset; edge++)
                {
                    graph[r.TopLeftY + yOffset, r.TopLeftY + yOffset < 10 ? edge: edge - 1 ] = "-";
                    graph[r.TopLeftY + r.Height + yOffset - 1, r.TopLeftY + r.Height + yOffset < 10 ? edge : edge - 1] = "_";
                }


                //print rectangle left and right edge
                for (int edge = r.TopLeftY; edge <= r.TopLeftY + r.Height - 1; edge++)
                {
                    graph[edge + yOffset, edge < 10 ? r.TopLeftX * 2 + xOffset : r.TopLeftX * 2 + xOffset - twoDigitOffset] = "|";
                    graph[edge + yOffset, edge < 10 ? xEdgeLen + xOffset : xEdgeLen + xOffset - twoDigitOffset] = "|";
                }
            }

            //print on the screen
            for (int y = 0; y <= yLength - 1; y++)
            {
                for (int x = 0; x <= xCoorLength - 1; x++)
                {
                    Console.Write(graph[y, x]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }

        private bool IsOutOfGrid(int coorX, int coorY)
        {
            //grid coordinates range from 0 - 24
            if ((coorX < 0 && coorX > Constant.MaxGridLength) ||
                (coorY < 0 && coorY > Constant.MaxGridLength))
                return true;

            return false;
        }

        private bool IsRectangleExtendGrid(int coorX, int coorY, int width, int height)
        {
            if ((coorX + width > X) || (coorY + height > Y))
                return true;

            return false;
        }

        private bool IsInRegctangle(Rectangle rectangle, int findRectangleX, int findRectangleY)
        {
            if (rectangle.TopLeftX <= findRectangleX && (rectangle.TopLeftX + rectangle.Width) >= findRectangleX
                && rectangle.TopLeftY <= findRectangleY && (rectangle.TopLeftY + rectangle.Height) >= findRectangleY)
                return true;

            return false;
        }
    }
}

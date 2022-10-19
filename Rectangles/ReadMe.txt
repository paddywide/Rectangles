In this software, you can create a grid and rectangles. The grid X and Y axis ranges from 5 to 25. The coordinate starts with 0. Once the grid is created, a rectangle is allowed to be created on the grid. 

You can add a rectangle by specifying the top left corner X and Y coordinate, the width and the height of the rectangle. The rectangle must not extend beyond the edge of the grid. Rectangles must not overlap with existing rectangles. The top left corner X and Y coordinates start with 0. For example grid.AddRectangle(5, 5, 10, 10);

It can find a rectangle by specifying a point on the grid. If the point sits in any rectangle, it will return the index stored in the Grid class. For example grid.FindRectangleIdx(2, 4);

It can remove a rectangle by specifying a point on the grid. If the point sits in any rectangle, it will return true for success or false for failure. For example grid.RemoveRectangle(2, 4).

The rectangle will not be allowed to exceed the grid, and it won’t be able to create. Also, each rectangle is not allowed to overlap with others. There is a Display() method to show all the rectangles in the console.
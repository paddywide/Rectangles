namespace Rectangles
{
    public class Program
    {
        static void Main(string[] args)
        {
            Grid gridA = new Grid(20, 20);
            //gridA.AddRectangle(1, 1, 10, 10);

            gridA.AddRectangle(5, 5, 10, 10);
            gridA.AddRectangle(2, 7, 4, 4);

            gridA.DisplayGrid();
        }
    }
}

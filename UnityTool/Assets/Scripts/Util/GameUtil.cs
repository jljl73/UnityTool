namespace Mignon.Util
{
    public class MapUtil
    {
        public static int PointToId(int x, int y, int width)
        {
            return x * width + y;
        }

        public static (int, int) IdToPoint(int id, int width)
        {
            int x = id / width;
            int y = id % width;
            return (x, y);
        }

        public static (int, int) IdToCentPoint(int id, int width)
        {
            int x = id / width - (width >> 1);
            int y = id % width - (width >> 1);
            return (x, y);
        }
    }
}

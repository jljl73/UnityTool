using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}

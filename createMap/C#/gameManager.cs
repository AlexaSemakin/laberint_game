using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagerGameLab 
{
    public static class ManagerGame
    {
        static Map map { get; set; }
        public static void GenerateMap(SizeMap sizeMap)
        {
            map = new Map(sizeMap);
        }
    }
    /// <summary>
    ///  Класс Map
    ///  класс определяющий карту
    /// </summary>
    class Map
    {
        List<List<List<DotElement>>> matrix;
        SizeMap sizeMap;
        public Map(SizeMap sizeMap)
        {
            this.sizeMap = sizeMap;
            for (int i = 0; i < sizeMap.length; i++)
            {
                matrix.Add(new List<List<DotElement>>());
                for (int j = 0; j < sizeMap.width; j++)
                {
                    matrix[i].Add(new List<DotElement>());
                    for (int k = 0; k < sizeMap.height; k++)
                    {
                        matrix[i][j].Add(new DotElement());
                    }
                }
            }
            dfs(new Point(0,0,0), new Point(-1, -1, -1));
        }

        List<int> generate_goToVector()
        {
            Random rand = new Random();
            List<int> elements = new List<int>();
            List<int> go_to_vector = new List<int>();

            for (int i = 0; i < GoTo3D.CountFacet; i++)
            {
                elements.Add(i);
            }
            while (elements.Count > 0)
            {
                int index = rand.Next(0, elements.Count);
                int value = elements[index];
                go_to_vector.Add(value);
                elements.RemoveAt(index);
            }
            return go_to_vector;
        }

        void dfs(Point now, Point was)
        {
            matrix[now.X][now.Y][now.Z].walls = new List<bool>() { false, false, false, false, false, false};
            List<int> goToVector = generate_goToVector();
            foreach (var item in goToVector)
            {
                Point to = new Point(now.X +GoTo3D.GoToArray[item, 0], now.Y + GoTo3D.GoToArray[item, 1],now.Z + GoTo3D.GoToArray[item, 2]);

                if (to.X != was.X || to.Y != was.Y || to.Z != was.Z)
                {
                    if ((to.X < 0) || (to.X >= sizeMap.length) || (to.Y < 0) || (to.Y >= sizeMap.height) || (to.Z < 0) || (to.Z >= sizeMap.width) || matrix[to.X][to.Y][to.Z].walls != null)
                    {
                        matrix[now.X][now.Y][now.Z].walls[item] = true;
                    }
                    else
                    {
                        dfs(to, now);
                    }
                }
            }

        }
    }
    public class DotElement
    {
        public List<bool> walls { get; set; }
        public DotElement()
        {
            walls = null;
        }
        public DotElement( List<bool> walls) {
            this.walls = walls;   
        }
       
        public bool getBack() {
            return walls[0];
        }
        public bool getRight()
        {
            return walls[1];
        }
        public bool getFront()
        {
            return walls[2];
        }
        public bool getLeft()
        {
            return walls[3];
        }
        public bool getTop()
        {
            return walls[4];
        }
        public bool getBottom()
        {
            return walls[5];
        }
    }

    /// <summary>
    ///  Класс SizeMap
    ///  класс определяющий размер карты
    /// </summary>
    public class SizeMap
    {
        int l, w, h;
        public SizeMap(int l, int w, int h)
        {
            this.l = l;
            this.w = w;
            this.h = h;
        }

        /// <remarks name="length">
        ///  Поле length
        ///  длина карты
        /// </remarks>

        public int length { get { return l; } }

        /// <remarks name="width">
        ///  Поле length
        ///  ширина карты
        /// </remarks>

        public int width { get { return w; } }

        /// <remarks name="height">
        ///  Поле length
        ///  высота карты
        /// </remarks>

        public int height { get { return h; } }
    }
    static class GoTo3D
    {
        public static int[,] GoToArray = { { -1, 0, 0 }, { 0, 1, 0 }, { 1, 0, 0 }, { 0, -1, 0 }, { 0, 0, 1 }, { 0, 0, -1 } };
        public static int CountFacet = 6;
    }

    public class Point {
        public Point(int x, int y, int z) {
            X = x;
            Y = y;
            Z = z;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }
}
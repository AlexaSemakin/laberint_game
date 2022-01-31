using System.Collections;
using System.Collections.Generic;
using System;



namespace ManagerGameLab
{
    public static class ManagerGame
    {
        public static Map map { get; set; }
        public static void GenerateMap(SizeMap sizeMap)
        {
            map = new Map(sizeMap);
        }
        public static DotElement getElement(Point point)
        {
            return map.matrix[point.X][point.Y][point.Z];
        }
        public static DotElement getElement(int x, int y, int z)
        {
            return map.matrix[x][y][z];
        }
        public static int? getLengthToStart(int x, int y, int z)
        {
            return map.matrix[x][y][z].LenthToStart;
        }
    }
    /// <summary>
    ///  Класс Map
    ///  класс определяющий карту
    /// </summary>
    public class Map
    {
        private Random rand;
        public List<List<List<DotElement>>> matrix;
        private SizeMap sizeMap;
        private Stack<ToGo> stack;
        public Map(SizeMap sizeMap)
        {
            rand = new Random();
            this.sizeMap = sizeMap;
            matrix = new List<List<List<DotElement>>>();
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
            dfs(new Point(0, 0, 0), new Point(-1, -1, -1));
        }

        private List<int> generate_goToVector()
        {
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

        private void dfs(Point now, Point was)
        {
            stack = new Stack<ToGo>();
            stack.Push(new ToGo(now, was, 0));
            while (stack.Count > 0)
            {
                ToGo toGo = stack.Pop();
                if (matrix[toGo.now.X][toGo.now.Y][toGo.now.Z].walls == null) {
                    matrix[toGo.now.X][toGo.now.Y][toGo.now.Z].walls = new List<bool>() { false, false, false, false, false, false };
                    if (matrix[toGo.now.X][toGo.now.Y][toGo.now.Z].LenthToStart == null || matrix[toGo.now.X][toGo.now.Y][toGo.now.Z].LenthToStart > toGo.childLength)
                    {
                        matrix[toGo.now.X][toGo.now.Y][toGo.now.Z].LenthToStart = toGo.childLength;
                    }
                    List<int> goToVector = generate_goToVector();
                    foreach (var item in goToVector)
                    {
                        Point to = new Point(toGo.now.X + GoTo3D.GoToArray[item, 0], toGo.now.Y + GoTo3D.GoToArray[item, 1], toGo.now.Z + GoTo3D.GoToArray[item, 2]);

                        if (to.X != toGo.was.X || to.Y != toGo.was.Y || to.Z != toGo.was.Z)
                        {
                            if ((to.X < 0) || (to.X >= sizeMap.length) || (to.Y < 0) || (to.Y >= sizeMap.width) || (to.Z < 0) || (to.Z >= sizeMap.height))
                            {
                                matrix[toGo.now.X][toGo.now.Y][toGo.now.Z].walls[item] = true;
                            }
                            else if (matrix[to.X][to.Y][to.Z].walls != null) {
                                matrix[toGo.now.X][toGo.now.Y][toGo.now.Z].walls[item] = true;
                            }
                            else
                            {
                                stack.Push(new ToGo(to, toGo.now, matrix[toGo.now.X][toGo.now.Y][toGo.now.Z].LenthToStart + 1));
                            }
                        }
                    }
                }
            }
        }
    }

    internal class ToGo
    {
        public Point now, was;
        public int? childLength = null;
        public ToGo(Point Now, Point WasGo, int? childLength)
        {
            this.now = Now;
            this.was = WasGo;
            this.childLength = childLength;
        }

    }

    public class DotElement
    {
        public List<bool> walls { get; set; }
        public int? LenthToStart = null;
        public DotElement()
        {
            walls = null;
        }
        public DotElement(List<bool> walls)
        {
            this.walls = walls;
        }

        public override string ToString()
        {
            string s = "";
            foreach (var item in walls)
            {
                s+= item == true ? "1" : "0";
            }
            return s;
        }

       public bool getBack()
        {
            return walls[0];
        }
        public bool getRight()
        {
            return walls[4];
        }
        public bool getFront()
        {
            return walls[2];
        }
        public bool getLeft()
        {
            return walls[5];
        }
        public bool getTop()
        {
            return walls[1];
        }
        public bool getBottom()
        {
            return walls[3];
        }
    }

    /// <summary>
    ///  Класс SizeMap
    ///  класс определяющий размер карты
    /// </summary>
    public class SizeMap
    {
        private int l, w, h;
        public SizeMap(int l, int w, int h)
        {
            this.l = l;
            this.w = w;
            this.h = h;
        }
        public SizeMap(Point point)
        {
            this.l = point.X;
            this.w = point.Y;
            this.h = point.Z;
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

    internal static class GoTo3D
    {
        public static readonly int[,] GoToArray = {
            { -1, 0, 0 },
            { 0, 1, 0 },
            { 1, 0, 0 },
            { 0, -1, 0 },
            { 0, 0, 1 },
            { 0, 0, -1 }
        };
        public static int CountFacet = 6;
    }

    public class Point
    {
        public Point(int n)
        {
            X = n;
            Y = n;
            Z = n;
        }
        public Point(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }
}
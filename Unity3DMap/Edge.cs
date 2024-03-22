using System;
namespace Unity3DMap
{
    public class Edge
    {
        public Point First;
        public Point Second;

        public Edge(Point first, Point second)
        {
            First = first;
            Second = second;
        }

        public double Length
        {
            get { return Math.Sqrt(Math.Pow(Second.X - First.X, 2) + Math.Pow(Second.Y - First.Y, 2)); }
        }
    }
}


using System;
namespace Unity3DMap
{
    public class Point
    {
        public double X;
        public double Y;
        public int FloorNumber;
        public int ClassRoomNumber;
        public string Info;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}


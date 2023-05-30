using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Demos.HackerU.HomeWork.HW_16.Point;

namespace Demos.HackerU.HomeWork.HW_16
{
    public class Point
    {
        private int x;
        private int y;
        public int X { get {return x;}set { x = value; CheckEquality(); } }
        public int Y { get { return y; } set { y = value; CheckEquality(); } }

        public event EventHandler<PointEventArgs> PointEquals= null;

        public Point()
        {
          x = 0;
          y = 0;
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void CheckEquality()
        {
            if (x == y)
            {
                {
                    PointEquals?.Invoke(this, new PointEventArgs(x));
                }
            } 
        }

        public override string ToString()
        {
            return $"X:{X}, Y:{Y}";
        }

        public class PointEventArgs: EventArgs
       {
          public int Value { get; set; }
            public int X { get; }
            public int Y { get; }

            public PointEventArgs(int value)
            {
                Value = value;
            }

            public PointEventArgs(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

       public class PointsList
        {
            public event EventHandler<PointEventArgs> PointAdded;
            public event EventHandler<PointEventArgs> PointRemoved;

            public List<Point> inner;
            public PointsList()
            {
                inner = new List<Point>();
            }

            public void AddPoint(Point point)
            {
                inner.Add(point) ;
                PointAdded.Invoke(this,new PointEventArgs(point.X,point.Y));
            }

            public void AddPoint(int x, int y)
            {
                Point point = new Point(x, y);
                AddPoint(point);
            }

            public void RemovePoint(int x, int y)
            {
                Point pointToRemove = inner.Find(p => p.X == x && p.Y == y);
                if (pointToRemove != null)
                {
                    inner.Remove(pointToRemove);
                    PointRemoved.Invoke(this, new PointEventArgs(x, y));
                }
            }

           public void RemovePoint(int index)
            {
                if (index >= 0 && index < inner.Count)
                {
                    Point PointIndex = inner[index];
                    inner.RemoveAt(index);
                    PointRemoved.Invoke(this, new PointEventArgs(PointIndex.X, PointIndex.Y));
                }
            }
        }




    }


}

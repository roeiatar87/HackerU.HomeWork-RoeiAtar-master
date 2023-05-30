using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Demos.HackerU.HomeWork.HW_16.Point;

namespace Demos.HackerU.HomeWork.HW_16
{
    public class PointS
    {

        public static void Run()
        {
            Point p = new Point();
            p.PointEquals += Point_PointEquals;

            p.X = 3; 
            p.Y = 3; // Event will be triggered

            p.X = 4;
            p.Y = 5;

            p.X = 7;
            p.Y = 7; // Event will be triggered


            PointsList pointsList = new PointsList();
            pointsList.PointAdded += PointsList_PointAdded;
            pointsList.PointRemoved += PointsList_PointRemoved;

           

            pointsList.AddPoint(3, 3); // Event will be triggered
            pointsList.AddPoint(5, 5); // Event will be triggered

            pointsList.RemovePoint(3, 3); // Event will be triggered

            pointsList.RemovePoint(1); // Event will be triggered


            GlobalArray<int> Intglobal = new GlobalArray<int>(10);
            GlobalArray<string> stringGlobal = new GlobalArray<string>(10);
            GlobalArray<bool> boolGlobal = new GlobalArray<bool>(10);
            GlobalArray<Point> pointGlobal = new GlobalArray<Point>(10);

            Intglobal.AddOrUpdateEvent += GlobalArray_ItemAdd;
            Intglobal.AddOrUpdate(1, 7);

            stringGlobal.AddOrUpdateEvent += GlobalArray_ItemAdd;
            stringGlobal.AddOrUpdate(2,"matan gaida");

            boolGlobal.AddOrUpdateEvent += GlobalArray_ItemAdd;
            boolGlobal.AddOrUpdate(3, true);

            pointGlobal.AddOrUpdateEvent += GlobalArray_ItemAdd;
            pointGlobal.AddOrUpdate(4, p);
        }


        public static void Point_PointEquals(object sender, PointEventArgs e)
        {
            Console.WriteLine($"x and y are equal. Value: {e.Value}");
        }


        public static void PointsList_PointAdded(object sender, PointEventArgs e)
        {
            Console.WriteLine($"Point added. X: {e.X}, Y: {e.Y}");
        }

        public static void PointsList_PointRemoved(object sender, PointEventArgs e)
        {
            Console.WriteLine($"Point removed. X: {e.X}, Y: {e.Y}");
        }

        public static void GlobalArray_ItemAdd<T>(object sender, GlobalArrayEventArgs<T> e)
        {
            Console.WriteLine($"new item updated.  Item: {e.Item}, Index: {e.Index}");
        }


    }


}


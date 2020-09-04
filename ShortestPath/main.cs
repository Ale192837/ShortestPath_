using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ShortestPath
{
    class main
    {
        static PathSystem p = new PathSystem();
        static void Main()
        {
            Point v0 = new Point();
            Point v1 = new Point();
            Point v2 = new Point();
            Point v3 = new Point();
            Point v4 = new Point();
            Point v5 = new Point();

            v0.distances.Add(new Edge(1, 10));
            v0.distances.Add(new Edge(2, 5));
            v1.distances.Add(new Edge(0, 10));
            v1.distances.Add(new Edge(2, 3));
            v1.distances.Add(new Edge(3, 1));
            v2.distances.Add(new Edge(0, 5));
            v2.distances.Add(new Edge(1, 3));
            v2.distances.Add(new Edge(3, 8));
            v2.distances.Add(new Edge(4, 2));
            v3.distances.Add(new Edge(1, 1));
            v3.distances.Add(new Edge(2, 8));
            v3.distances.Add(new Edge(4, 4));
            v3.distances.Add(new Edge(5, 4));
            v4.distances.Add(new Edge(2, 2));
            v4.distances.Add(new Edge(3, 4));
            v4.distances.Add(new Edge(5, 6));
            v5.distances.Add(new Edge(3, 4));
            v5.distances.Add(new Edge(4, 6));
            v0.id = 0;
            v1.id = 1;
            v2.id = 2;
            v3.id = 3;
            v4.id = 4;
            v5.id = 5;

            p.points.Add(v5);
            p.points.Add(v4);
            p.points.Add(v2);
            p.points.Add(v1);
            p.points.Add(v3);
            p.points.Add(v0);

            List<Point> P = p.Path(0, 4);
            foreach(Point a in P)
            {
                Console.WriteLine(a.id);
            }
            
        }
    }
}

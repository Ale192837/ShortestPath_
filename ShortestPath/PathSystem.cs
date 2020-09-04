using System;
using System.Collections.Generic;
using System.Linq;

namespace ShortestPath
{
    
    public class PathSystem
    {
        public List<Point> points = new List<Point>();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="startPoint">Initial point of path</param>
        /// <param name="endPoint">Final point of path</param>
        /// <returns>Ordered list of points connecting the start and end points by the shortest path</returns>
        public List<Point> Path(int startPoint, int endPoint)
        {
            List<Point> openPointsAux = new List<Point>();
            List<int> openPoints;

            for (int v = 0; v < points.Count; v++)
            {
                if (points[v].id == startPoint) points[v].estimate = 0;
                else points[v].estimate = float.PositiveInfinity / 2;
                points[v].precessor = -1;
            }

            points.Sort(delegate (Point p1, Point p2)
            {
                return p1.id.CompareTo(p2.id);
            });

            while (points.FindAll(p => p.close == false).Count > 0)
            {
                openPointsAux = points.FindAll(p => p.close == false);
                openPoints = new List<int>();
                foreach(Point p in openPointsAux)
                {
                    openPoints.Add(p.id);
                }

                float estimateBuffer = float.PositiveInfinity;
                int currentPoint = 0;
                foreach (int p in openPoints)
                {
                    if(points[p].estimate <= estimateBuffer)
                    {
                        estimateBuffer = points[p].estimate;
                        currentPoint = points[p].id;
                    }
                }

                points[currentPoint].close = true;
                points = DijkstraAlgorithm(currentPoint, points, openPoints);
            }

            Point r;
            r = points[endPoint];
            List<Point> path = new List<Point>();

            while (true)
            {
                if (r != points[startPoint])
                {
                    path.Add(r);
                    r = points[r.precessor];
                }
                else 
                {
                    path.Reverse();
                    return path;
                 }
            }
        }

        private List<Point> DijkstraAlgorithm(int currentPoint, List<Point> points, List<int> openPoints)
        {
            Point mainPoint = points.Find(p => p.id == currentPoint);
            mainPoint.close = true;
            foreach (Edge idPoint in mainPoint.distances)
            {
                if (!points[idPoint.verticeId].close)
                {
                    foreach(Edge e in points[idPoint.verticeId].distances)
                    {
                        if (e.verticeId == currentPoint)
                        {
                            float newEstimate = mainPoint.estimate + e.distance;
                            if (newEstimate < points[idPoint.verticeId].estimate)
                            {
                                points[idPoint.verticeId].estimate = newEstimate;
                                points[idPoint.verticeId].precessor = mainPoint.id;
                            }
                        }
                    }
                }
            }
            return points;
        }
    }

    public class Point
    {
        public float estimate;
        public bool close = false;
        public int id, precessor;
        public List<Edge> distances = new List<Edge>();
    }

    public class Edge
    {
        public int verticeId;
        public float distance;

        public Edge(int VerticeId, float Distance)
        {
            verticeId = VerticeId;
            distance = Distance;
        }
    }

}

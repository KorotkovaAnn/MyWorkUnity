using System;
namespace Unity3DMap
{
    public class Graph
    {
        public List<Point> points = new List<Point>();
        public List<Edge> edges = new List<Edge>();

        public double[,] Matrix;

        public Graph(List<Point> points, List<Edge> edges)
        {
            this.points = points;
            this.edges = edges;
            Matrix = new double[points.Count, points.Count];
        }

        public void CreateGraph()
        {
            for (int i = 0; i < points.Count; i++)
            {
                for (int j = 0; j < points.Count; j++)
                {
                    var edge = edges.FirstOrDefault(e =>
                    {
                        return e.First == points[i] && e.Second == points[j] || e.Second == points[i] && e.First == points[j];
                    });
                    if (edge != null)
                    {
                        Matrix[i, j] = edge.Length;
                    }
                    else
                    {
                        Matrix[i, j] = 0;
                    }

                }
            }
        }

        public void PrintGraph()
        {
            for (int i = 0; i < points.Count; i++)
            {
                for (int j = 0; j < points.Count; j++)
                {
                    Console.Write(string.Format("{0:f1}", Matrix[i, j] + "\t"));
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        public double Dijkstra(Point start, Point end)
        {
            Dictionary<Point, double> distances = new Dictionary<Point, double>();
            HashSet<Point> visited = new HashSet<Point>();

            foreach (var point in points)
            {
                distances[point] = double.PositiveInfinity;
            }

            distances[start] = 0;

            while (visited.Count < points.Count)
            {
                Point current = null;
                double minDistance = double.PositiveInfinity;

                foreach (var point in points)
                {
                    if (!visited.Contains(point) && distances[point] < minDistance)
                    {
                        current = point;
                        minDistance = distances[point];
                    }
                }

                if (current == null)
                {
                    break;
                }

                visited.Add(current);

                foreach (var edge in edges)
                {
                    if (edge.First == current)
                    {
                        double distanceThroughCurrent = distances[current] + edge.Length;
                        if (distanceThroughCurrent < distances[edge.Second])
                        {
                            distances[edge.Second] = distanceThroughCurrent;
                        }
                    }
                }
            }

            return distances[end];
        }

        public List<Point> ShortestWay(Point start, Point end)
        {
            Dictionary<Point, double> distances = new Dictionary<Point, double>();
            // Словарь для хранения предшествующих точек на кратчайшем пути
            Dictionary<Point, Point> previous = new Dictionary<Point, Point>();
            HashSet<Point> visited = new HashSet<Point>();

            foreach (var point in points)
            {
                distances[point] = double.PositiveInfinity;
            }

            distances[start] = 0;

            while (visited.Count < points.Count)
            {
                Point current = null;
                double minDistance = double.PositiveInfinity;

                foreach (var point in points)
                {
                    if (!visited.Contains(point) && distances[point] < minDistance)
                    {
                        current = point;
                        minDistance = distances[point];
                    }
                }

                if (current == null)
                {
                    break;
                }

                visited.Add(current);

                foreach (var edge in edges)
                {
                    if (edge.First == current)
                    {
                        double distanceThroughCurrent = distances[current] + edge.Length;
                        if (distanceThroughCurrent < distances[edge.Second])
                        {
                            distances[edge.Second] = distanceThroughCurrent;
                            previous[edge.Second] = current; // Обновляем предшествующую вершину на кратчайшем пути
                        }
                    }
                }
            }

            // Формирование списка точек кратчайшего пути
            List<Point> shortestPath = new List<Point>();
            Point currentPoint = end;

            while (currentPoint != null)
            {
                shortestPath.Insert(0, currentPoint); // Добавляем текущую точку в начало списка (чтобы путь был в порядке от начала к концу)
                currentPoint = previous.ContainsKey(currentPoint) ? previous[currentPoint] : null; // Переходим к предшествующей точке на кратчайшем пути
            }

            return shortestPath;
        }
    }
}


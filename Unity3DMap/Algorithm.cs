using System;
namespace Unity3DMap
{
	public class Algorithm
	{
		private Graph graph;
		private Point start;
		private Point end;

		public Algorithm(Graph graphs, Point Start, Point End)
		{
            graph = graphs;
            start = Start;
            end = End;
		}

        public double Dijkstra()
        {
            Dictionary<Point, double> distances = new Dictionary<Point, double>();
            HashSet<Point> visited = new HashSet<Point>();

            foreach (var point in graph.points)
            {
                distances[point] = double.PositiveInfinity;
            }

            distances[start] = 0;

            while (visited.Count < graph.points.Count)
            {
                Point current = null;
                double minDistance = double.PositiveInfinity;

                foreach (var point in graph.points)
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

                foreach (var edge in graph.edges)
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
    }
}



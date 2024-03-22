using Unity3DMap;

public class Program
{
    public static void Main()
    {
        List<Point> points = new List<Point>()
        {
            new Point(0, 0),
            new Point(0, 2),
            new Point(0, 4),
            new Point(1, 1),
            new Point(3, 3),

        };
        List<Edge> edges = new List<Edge>()
        {
            new Edge(points[0], points[3]),
            new Edge(points[0], points[1]),
            new Edge(points[3], points[1]),
            new Edge(points[1], points[2]),
            new Edge(points[1], points[4]),
            new Edge(points[2], points[4]),
        };

        Graph graph = new Graph(points, edges);
        graph.CreateGraph();
        graph.PrintGraph();

        //Algorithm algorithm = new Algorithm(graph, points[0], points[4]);
        //double shortdistance = algorithm.Dijkstra();
        //Console.WriteLine($"Кратчайшее расстояние между точками: {shortdistance}");
        //Console.ReadLine();

        double shortdistance2 = graph.Dijkstra(points[0], points[4]);
        Console.WriteLine($"Кратчайшее расстояние между точками: {shortdistance2}");
        Console.ReadLine();

        List<Point> TestWay = new List<Point>();
        TestWay = graph.ShortestWay(points[0], points[4]);
        Console.WriteLine("Кратчайший путь:");
        foreach (var point in TestWay)
        {
            Console.WriteLine($"({point.X}, {point.Y})");
        }
        Console.ReadLine();
    }
}


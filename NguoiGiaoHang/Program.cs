using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Edge
{
    public int From { get; set; }
    public int To { get; set; }
    public double Length { get; set; }

    public Edge(int from, int to, double length)
    {
        From = from;
        To = to;
        Length = length;
    }
}

public class TSP
{
    public static void SolveTSP(List<Edge> edges)
    {
        edges.Sort((e1, e2) => e1.Length.CompareTo(e2.Length));

        List<Edge> chuTrinh = new List<Edge>();
        double gia = 0.0;

        while (edges.Count > 0)
        {
            Edge e = edges[0];
            edges.RemoveAt(0); 

            if (CanSelectEdge(chuTrinh, e))
            {
                chuTrinh.Add(e);
                gia += e.Length;
            }
        }

        Console.WriteLine("Chu trình tối ưu:");
        foreach (var edge in chuTrinh)
        {
            Console.WriteLine($"Từ {edge.From} đến {edge.To} với độ dài {edge.Length}");
        }
        Console.WriteLine($"Tổng độ dài: {gia}");
    }

    private static bool CanSelectEdge(List<Edge> chuTrinh, Edge e)
    {
        int fromCount = 0;
        int toCount = 0;

        foreach (var edge in chuTrinh)
        {
            if (edge.From == e.From || edge.To == e.From)
                fromCount++;
            if (edge.From == e.To || edge.To == e.To)
                toCount++;
        }

        if (fromCount >= 2 || toCount >= 2)
            return false;
        return true;
    }

    public static void Main()
    {
        List<Edge> edges = new List<Edge>
        {
            new Edge(1, 2, 10),
            new Edge(1, 3, 15),
            new Edge(1, 4, 20),
            new Edge(2, 3, 35),
            new Edge(2, 4, 25),
            new Edge(3, 4, 30)
        };

        SolveTSP(edges);
    }
}

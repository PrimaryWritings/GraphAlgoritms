using System;

public class GraphAlg
{
	 // DFS
    private void Depth(int v, bool[] visited)
    {
        visited[v] = true;
        Console.Write(v + " ");

        foreach (int i in List[v])
        {
            if (!visited[i])
            {
                Depth(i, visited);
            }
        }
    }
    public void Deth()
    {
        bool[] visited = new bool[size];
        for (int i = 0; i < size; i++)
        {
            if (!visited[i])
            {
                Depth(i, visited);
            }
        }
    }

    // BFS
    public void Level(int s)
    {
        bool[] visited = new bool[size];
        int[] queue = new int[size];
        int Now = 0;
        int Next = 0;
        visited[s] = true;
        queue[Next++] = s;

        while (Now != Next)
        {
            s = queue[Now++];
            Console.Write(s + " ");

            foreach (int i in List[s])
            {
                
                if (!visited[i])
                {
                    visited[i] = true;
                    queue[Next++] = i;
                }
            }
        }
    }


    // Dijkstra-Prim's algorithm
    private int MinKey(int[] key, bool[] mstSet)
    {
        int min = int.MaxValue, minIndex = -1;

        for (int v = 0; v < size; v++)
        {
            if (mstSet[v] == false && key[v] < min)
            {
                min = key[v];
                minIndex = v;
            }
        }
        return minIndex;
    }
    public void PrimMST()
    {
        int[] parent = new int[size];
        int[] key = new int[size];
        bool[] mstSet = new bool[size];
        for (int i = 0; i < size; i++)
        {
            key[i] = int.MaxValue;
            mstSet[i] = false;
        }
        key[0] = 0;
        parent[0] = -1;
        for (int count = 0; count < size - 1; count++)
        {
            int u = MinKey(key, mstSet);
            mstSet[u] = true;

            for (int v = 0; v < size; v++)
            {
                if (Value[u, v] != 0 && mstSet[v] == false && Value[u, v] < key[v])
                {
                    parent[v] = u;
                    key[v] = Value[u, v];
                }
            }
        }
        Console.WriteLine("Вершины\t Вес");
        for (int i = 1; i < size; i++)
        {
            Console.WriteLine(parent[i] + " - " + i + "\t " + Value[i, parent[i]]);
        }
    }


    // Kruskal's algorithm
    private int Find(int[] parent, int i)
    {
        while (parent[i] != i)
        {
            i = parent[i];
        }
        return i;
    }
    private void Union(int[] parent, int x, int y)
    {
        int x_set = Find(parent, x);
        int y_set = Find(parent, y);
        parent[x_set] = y_set;
    }

    public void Kruskal()
    {
        int[] parent = new int[size];
        for (int i = 0; i < size; i++)
        {
            parent[i] = i;
        }
        int edgeCount = 0;
        Console.WriteLine("Rib\t Weight");
        while (edgeCount < size - 1)
        {
            int min = int.MaxValue;
            int a = -1, b = -1;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (Find(parent, i) != Find(parent, j) && Value[i, j] < min && Value[i, j] != 0)
                    {
                        min = Value[i, j];
                        a = i;
                        b = j;
                    }
                }
            }

            Union(parent, a, b);
            Console.WriteLine(a + " - " + b + "\t " + Value[a, b]);
            edgeCount++;
        }
    }


    //Finding the Shortest Path
    int MinDistance(int[] dist, bool[] sptSet)
    {
        int min = int.MaxValue, minIndex = -1;

        for (int v = 0; v < size; v++)
        {
            if (!sptSet[v] && dist[v] <= min)
            {
                min = dist[v];
                minIndex = v;
            }
        }

        return minIndex;
    }
    public void Dijkstra(int start, int end)
    {
        int[] ist = new int[size];
        bool[] visited = new bool[size];
        for (int i = 0; i < size; i++)
        {
            ist[i] = int.MaxValue;
            visited[i] = false;
        }
        ist[start] = 0;
        for (int count = 0; count < size - 1; count++)
        {
            int u = MinDistance(ist, visited);
            visited[u] = true;
            for (int v = 0; v < size; v++)
            {
                if (!visited[v] && Value[u, v] != 0 && ist[u] != int.MaxValue && ist[u] + Value[u, v] < ist[v])
                {
                    ist[v] = ist[u] + Value[u, v];
                }
            }
        }
        Console.WriteLine("The shortest path from " + start + " to " + end + " is: " + ist[end]);
    }

}

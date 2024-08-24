using System;

public class Graph
{
    public bool[,] Matrix;
    public int[,] Value;
    private List<List<int>> List;
    public int size;

    public Graph(int size_graph)
    {
        size = size_graph;
        Matrix = new bool[size, size];
        Value = new int[size, size];
        List = new List<List<int>>(size);
        for (int i = 0; i < size; i++)
        {
            List.Add(new List<int>());
        }
    }

    public void AddVertex()
    {
        size++;
        bool[,] newAdjMatrix = new bool[size, size];
        int[,] newAdjValue = new int[size, size];
        List<List<int>> newAdjList = new List<List<int>>(size);
        for (int i = 0; i < size - 1; i++)
        {
            newAdjList.Add(new List<int>());
            for (int j = 0; j < size - 1; j++)
            {
                newAdjMatrix[i, j] = Matrix[i, j];
                newAdjValue[i, j] = Value[i, j];
            }
        }
        newAdjList.Add(new List<int>());
        Matrix = newAdjMatrix;
        Value = newAdjValue;
        List = newAdjList;
    }

    public void RemoveVertex(int vertex)
    {
        if (vertex < 0 || vertex >= size)
        {

            return;
        }
        size--;
        bool[,] newAdjMatrix = new bool[size, size];
        int[,] newAdjValue = new int[size, size];
        List<List<int>> newAdjList = new List<List<int>>(size);
        int k = 0;
        for (int i = 0; i < size + 1; i++)
        {
            if (i == vertex)
            {
                continue;
            }
            newAdjList.Add(new List<int>());
            int l = 0;
            for (int j = 0; j < size + 1; j++)
            {
                if (j == vertex)
                {
                    continue;
                }

                newAdjMatrix[k, l] = Matrix[i, j];
                newAdjValue[k, l] = Value[i, j];
                if (Matrix[i, j])
                {
                    newAdjList[k].Add(j);
                }
                l++;
            }
            k++;
        }
        Value = newAdjValue;
        Matrix = newAdjMatrix;
        List = newAdjList;
    }

    public void AddEdge(int start, int end)
    {
        Random r = new Random();
        if (start < 0 || start >= size || end < 0 || end >= size)
        {
            Console.WriteLine("Incorrect index");
            return;
        }

        Matrix[start, end] = true;
        List[start].Add(end);
        Matrix[end, start] = true;
        List[end].Add(start);
        Value[start, end] = Value[end, start] = r.Next(1, 10);
    }

    public void RemoveEdge(int start, int end)
    {
        if (start < 0 || start >= size || end < 0 || end >= size)
        {
            Console.WriteLine("Incorrect index");
            return;
        }

        Matrix[start, end] = false;
        Value[start, end] = Value[end, start] = 0;
        List[start].Remove(end);
    }



    public void PrintGraph()
    {
        Console.WriteLine("Adjacency matrix:");
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(Matrix[i, j] ? "1 " : "0 ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("list of adjacencies:");
        for (int i = 0; i < size; i++)
        {
            Console.Write($"{i}: ");
            foreach (var vertex in List[i])
            {
                Console.Write($"{vertex} ");
            }
            Console.WriteLine();
        }
    }

    public void PrintValue()
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(Value[i, j] + " ");
            }
            Console.WriteLine();
        }
    }



    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(size);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    writer.Write(Matrix[i, j] ? "1 " : "0 ");
                }
                writer.WriteLine();
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    writer.Write(Value[i, j] + " ");
                }
                writer.WriteLine();
            }
        }
    }

    public void LoadFromFile(string fileName)
    {
        using (StreamReader reader = new StreamReader(fileName))
        {
            size = int.Parse(reader.ReadLine());
            Matrix = new bool[size, size];
            List = new List<List<int>>(size);
            Value = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                List.Add(new List<int>());
                string[] line = reader.ReadLine().Split(' ');
                for (int j = 0; j < size; j++)
                {
                    Matrix[i, j] = line[j] == "1";
                    if (line[j] == "1")
                    {
                        List[i].Add(j);
                    }
                }
            }
            for (int i = 0; i < size; i++)
            {
                string[] line = reader.ReadLine().Split(' ');
                for (int j = 0; j < size; j++)
                {
                    Value[i, j] = int.Parse(line[j]);

                }
            }

        }
    }


}


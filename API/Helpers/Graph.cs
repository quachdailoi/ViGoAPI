namespace API.Helpers
{
    public abstract class Vertex<T> where T : class
    {
        public HashSet<VertexWithWeight<T>> PreviousVertexsWithWeight { get; set; }
        public T Value { get; set; }
        public HashSet<VertexWithWeight<T>> NextVertexsWithWeight { get; set; }
        public abstract override bool Equals(object? obj);

        public abstract override int GetHashCode();
        public bool AddNextVertex(VertexWithWeight<T> vertex)
        {
            if(PreviousVertexsWithWeight.Contains(vertex)) return false;

            return NextVertexsWithWeight.Add(vertex);
        }
        public bool AddPreviousVertex(VertexWithWeight<T> vertex)
        {
            if (NextVertexsWithWeight.Contains(vertex)) return false;

            return PreviousVertexsWithWeight.Add(vertex);
        }

        //public bool RemoveVertexInPreviousVertex(VertexWithWeight<T> vertex)
        //{
        //    return PreviousVertexsWithWeight.Remove(vertex);
        //}

        //public bool RemoveVertexInNext

        //public void Remove()
        //{
        //    base = null;
        //}
    }
    public class VertexWithWeight<T> where T : class
    {
        public Vertex<T> Vertex { get; set; }
        public double WeightNumber { get; set; }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Vertex.GetHashCode();
        }
    }
    public class Path<T> where T : class
    {
        public List<Vertex<T>> Vertices { get; set; }
    }
    public class Graph<T> where T : class
    {
        public HashSet<Vertex<T>> Vertexs { get; set; } = new();
        public bool Add(Vertex<T> vertex)
        {
            return Vertexs.Add(vertex);
        }

        public bool AddEdge(Vertex<T> srcVertex, Vertex<T> destVertex, double weightNumber)
        {
            if(Vertexs.TryGetValue(srcVertex, out var _srcVertex) &&
               Vertexs.TryGetValue(destVertex, out var _destVertex))
            {
                return _srcVertex.AddNextVertex(
                            new VertexWithWeight<T>
                            {
                                Vertex = _destVertex,
                                WeightNumber = weightNumber
                            }) &&
                        _destVertex.AddPreviousVertex(
                            new VertexWithWeight<T>
                            {
                                Vertex = _srcVertex,
                                WeightNumber = weightNumber
                            });
            }
            return false;
        }
        public bool RemoveVerTex(Vertex<T> vertex)
        {
            if(Vertexs.TryGetValue(vertex, out var _vertex))
            {
                Vertexs.Remove(vertex);
                vertex = null;
                return true;
            }
            return false;
        }

        public Dictionary<Vertex<T>, Path<T>>? GetShortestPath(Vertex<T> srcVertex, Vertex<T> destVertex, int maximunVertexPerPath)
        {
            if (!Vertexs.Any()) return null;

            HashSet<Vertex<T>> visitedVertexs = new();

            HashSet<Vertex<T>> visitedParentVertexs = new();

            Dictionary<Vertex<T>, double> dist = new();

            Dictionary<Vertex<T>, Path<T>> pathToVertexs = new();

            dist.Add(srcVertex, 0);
            var currentVertex = srcVertex;

            while (true)
            {
                    visitedVertexs.Add(currentVertex);
                    foreach (var childVertexWithWeight in currentVertex.NextVertexsWithWeight)
                    {
                        var childVertex = childVertexWithWeight.Vertex;

                        var edgeWeight = childVertexWithWeight.WeightNumber;

                        if (visitedVertexs.Contains(childVertex)) continue;

                        visitedParentVertexs.Add(childVertex);

                        double totalWeight = dist[currentVertex] + edgeWeight;

                        if (!dist.TryGetValue(childVertex, out var weight) || totalWeight < weight)
                        {
                            dist[childVertex] = totalWeight;
                            if (pathToVertexs.ContainsKey(childVertex)) pathToVertexs[childVertex].Vertices.Add(currentVertex);
                            else pathToVertexs[childVertex] = new Path<T> { Vertices = new List<Vertex<T>> { currentVertex } };
                            // save path
                        }
                    }

                    visitedParentVertexs.Remove(currentVertex);

                    if (visitedParentVertexs.Count == 0) break;

                    Vertex<T> nextVertex = null;
                    double minDist = -1;

                    foreach (var visitedParentVertex in visitedParentVertexs)
                    {
                        if (dist[visitedParentVertex] < minDist || minDist == -1)
                        {
                            minDist = dist[visitedParentVertex];
                            nextVertex = visitedParentVertex;
                        }
                    }

                    currentVertex = nextVertex;
            }

            return pathToVertexs;
        }
    }
}

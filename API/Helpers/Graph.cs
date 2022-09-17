namespace API.Helpers
{
    public abstract class VertexBase<T> where T : class
    {
        public abstract override bool Equals(object? obj);

        public abstract override int GetHashCode();
    }
    public class Vertex<T> where T : class
    {
        //public HashSet<VertexWithWeight<T>> PreviousVertexsWithWeight { get; set; }
        public T Value { get; set; }
        public HashSet<VertexWithWeight<T>> NextVertexsWithWeight { get; set; }
        
        public bool AddNextVertex(VertexWithWeight<T> vertex, bool requireShortestEdge = false)
        {
            if (requireShortestEdge && NextVertexsWithWeight.TryGetValue(vertex, out var nextVertex))
            {
                if (nextVertex.WeightNumber > vertex.WeightNumber)
                {
                    NextVertexsWithWeight.Remove(nextVertex);
                    return NextVertexsWithWeight.Add(vertex);
                }
                return false;
            }
            return NextVertexsWithWeight.Add(vertex);
        }

        public void RemoveNextVertex(VertexWithWeight<T> vertex) => NextVertexsWithWeight.Remove(vertex);
        //public bool AddPreviousVertex(VertexWithWeight<T> vertex)
        //{
        //    //if (NextVertexsWithWeight.Contains(vertex)) return false;
        //    //if (NextVertexsWithWeight.TryGetValue(vertex, out var nextVertex))
        //    //{
        //    //    if (nextVertex.WeightNumber > vertex.WeightNumber)
        //    //    {
        //    //        PreviousVertexsWithWeight.Remove(nextVertex);
        //    //        return PreviousVertexsWithWeight.Add(vertex);
        //    //    }
        //    //    return false;
        //    //}
        //    //return PreviousVertexsWithWeight.Add(vertex);
        //    return PreviousVertexsWithWeight.Add(vertex);
        //}

        public override bool Equals(object? obj)
        {
            return Value.Equals(((Vertex<T>)obj).Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
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
        public object? Value { get; set; }

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
        public List<VertexWithWeight<T>> Vertexs { get; set; } = new();
    }
    public class Graph<T> where T : class
    {
        public HashSet<Vertex<T>> Vertexs { get; set; } = new();
        public bool Add(Vertex<T> vertex)
        {
            return Vertexs.Add(vertex);
        }

        public bool Add(T value)
        {
            return Vertexs.Add(new Vertex<T> { Value = value });
        }

        public bool Contains(T value)
        {
            return Vertexs.Contains(new Vertex<T> { Value = value });
        }

        private bool AddEdge(Vertex<T> srcVertex, Vertex<T> destVertex, double weightNumber, bool requireShortestEdge = false, object? valueBelongToEdge = null)
        {
            if(Vertexs.TryGetValue(srcVertex, out var _srcVertex) &&
               Vertexs.TryGetValue(destVertex, out var _destVertex))
            {
                return _srcVertex.AddNextVertex(
                            new VertexWithWeight<T>
                            {
                                Vertex = _destVertex,
                                WeightNumber = weightNumber,
                                Value = valueBelongToEdge
                            },
                            requireShortestEdge
                            ); 
                    //&&
                    //    _destVertex.AddPreviousVertex(
                    //        new VertexWithWeight<T>
                    //        {
                    //            Vertex = _srcVertex,
                    //            WeightNumber = weightNumber
                    //        });
            }
            return false;
        }

        public bool AddEdge(T srcValue, T destValue, double weightNumber, bool requireShortestEdge = false, object? valueBelongToEdge = null)
        {
            return AddEdge(new Vertex<T> { Value = srcValue }, new Vertex<T> { Value = destValue }, weightNumber, requireShortestEdge, valueBelongToEdge);
        }


        public void RemoveEdge(Vertex<T> srcVertex, Vertex<T> destVertex)
        {
            if (Vertexs.TryGetValue(srcVertex, out var _srcVertex) &&
               Vertexs.TryGetValue(destVertex, out var _destVertex))
            {
                 _srcVertex.RemoveNextVertex(
                            new VertexWithWeight<T>
                            {
                                Vertex = _destVertex
                            }); 
                    //&&
                    //    _destVertex.AddPreviousVertex(
                    //        new VertexWithWeight<T>
                    //        {
                    //            Vertex = _srcVertex,
                    //            WeightNumber = weightNumber
                    //        });
            }

        }
        public void RemoveVertex(Vertex<T> vertex)
        {
            Vertexs.Remove(vertex);
        }

        public List<Tuple<T,double,object?>>? GetShortestPath(T srcValue, T destValue,int maximunVertexPerPath)
        {
            var srcVertex = new Vertex<T> { Value = srcValue };
            var destVertex = new Vertex<T> { Value = destValue };

            var shortestPaths = GetShortestPath(srcVertex,maximunVertexPerPath, out var dist);

            var pathToDest = shortestPaths[destVertex];

            if (pathToDest == null) return null;

            List<Tuple<T,double, object>> result = new();

            pathToDest.Vertexs.ForEach(vertexWithWeight =>
            {
                result.Add(new Tuple<T,double,object>(vertexWithWeight.Vertex.Value,dist[vertexWithWeight.Vertex], vertexWithWeight.Value));
            });

            return result;
        }

        private Dictionary<Vertex<T>, Path<T>>? GetShortestPath(Vertex<T> srcVertex, int maximunVertexPerPath, out Dictionary<Vertex<T>, double> dist)
        {
            dist = new();

            if (!Vertexs.Any()) return null;

            HashSet<Vertex<T>> visitedVertexs = new();

            HashSet<VertexWithWeight<T>> visitedParentVertexs = new();

            Dictionary<Vertex<T>, Path<T>> pathToVertexs = new();

            dist.Add(srcVertex, 0);
            var currentVertex = srcVertex;

            var currentVertexWithWeight = new VertexWithWeight<T> { Vertex = srcVertex};

            while (true)
            {
                    visitedVertexs.Add(currentVertex);
                    foreach (var childVertexWithWeight in currentVertex.NextVertexsWithWeight)
                    {
                        var childVertex = childVertexWithWeight.Vertex;

                        var edgeWeight = childVertexWithWeight.WeightNumber;

                        if (visitedVertexs.Contains(childVertex)) continue;

                        visitedParentVertexs.Add(childVertexWithWeight);

                        double totalWeight = dist[currentVertex] + edgeWeight;

                        if (!dist.TryGetValue(childVertex, out var weight) || totalWeight < weight)
                        {
                            dist[childVertex] = totalWeight;
                            if (pathToVertexs.ContainsKey(childVertex)) pathToVertexs[childVertex].Vertexs.Add(currentVertexWithWeight);
                            else pathToVertexs[childVertex] = new Path<T> { Vertexs = new List<VertexWithWeight<T>> { currentVertexWithWeight } };
                            // save path
                        }
                    }

                    visitedParentVertexs.Remove(currentVertexWithWeight);

                    if (visitedParentVertexs.Count == 0) break;

                    double minDist = -1;

                    foreach (var visitedParentVertex in visitedParentVertexs)
                    {
                        if (dist[visitedParentVertex.Vertex] < minDist || minDist == -1)
                        {
                            minDist = dist[visitedParentVertex.Vertex];
                            currentVertex = visitedParentVertex.Vertex;
                            currentVertexWithWeight = visitedParentVertex;
                        }
                    }
            }

            return pathToVertexs;
        }
    }
}

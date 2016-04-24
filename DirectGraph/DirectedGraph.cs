using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluttert.DirectGraph
{
    /// <summary>
    /// Directed graph
    /// </summary>
    public class DirectedGraph : IGraph
    {
        public DirectedGraph(int vertices)
        {
            this.vertices = vertices;
            edges = 0;
            adjacencyList = new List<int>[vertices];
            addedEdges = new List<int[]>();
            for (int v = 0; v < vertices; v++)
            {
                adjacencyList[v] = new List<int>();
            }
        }

        private readonly int vertices;
        private readonly List<int>[] adjacencyList;
        private readonly List<int[]> addedEdges;
        private int edges;

        /// <summary>
        /// Total amount of vertices in this graph
        /// </summary>
        /// <returns>integer, amount of vertices</returns>
        public int Vertices() => vertices;

        /// <summary>
        /// Total amount of edges in this graph
        /// </summary>
        /// <returns>integer, amount of edges</returns>
        public int Edges() => edges;

        /// <summary>
        /// Adds an edge from a vertex to another vertex (can be the same)
        /// </summary>
        /// <param name="vertexFrom">Id of vertex where the edge starts</param>
        /// <param name="vertexTo">Id of vertex where the edge ends</param>
        public void AddEdge(int vertexFrom, int vertexTo)
        {
            addedEdges.Add(new int[] { vertexFrom, vertexTo });
            adjacencyList[vertexFrom].Add(vertexTo);
            edges++;
        }

        /// <summary>
        /// Returns all vertices (id's) that are adjecent to this vertex
        /// </summary>
        /// <param name="vertex">id of vertex</param>
        /// <returns>List with ID's of connected vertices</returns>
        public IEnumerable<int> AdjecentVertices(int vertex) => adjacencyList[vertex];

        /// <summary>
        /// Standard representation of the directed graph
        /// </summary>
        /// <returns>string</returns>
        public override string ToString() => GraphUtil.Stringify(this);

        /// <summary>
        /// Creates a deepcopy of this graph
        /// </summary>
        /// <returns>Graph</returns>
        public DirectedGraph DeepCopy()
        {
            var copy = new DirectedGraph(Vertices());
            for (int e = 0; e < addedEdges.Count; e++)
            {
                copy.AddEdge(addedEdges[e][0], addedEdges[e][1]);
            }
            return copy;
        }

        /// <summary>
        /// Reverse the directed edges in the graph
        /// </summary>
        /// <returns></returns>
        public DirectedGraph Reverse()
        {
            var reversedGraph = new DirectedGraph(vertices);
            for (int v = 0; v < vertices; v++)
            {
                foreach (var w in AdjecentVertices(v))
                {
                    reversedGraph.AddEdge(w, v);
                }
            }
            return reversedGraph;
        }

        public int AddVertex()
        {
            throw new NotImplementedException();
        }
    }
}

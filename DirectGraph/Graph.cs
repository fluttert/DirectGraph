using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluttert.DirectGraph
{
    /// <summary>
    /// An undirected graph
    /// </summary>
    public class Graph : IGraph
    {
        /// <summary>
        /// Empty constructor: empty undirected graph without vertices and edges
        /// </summary>
        public Graph() : this(0) { }

        /// <summary>
        /// Create a undirected graph with N amount of vertices
        /// </summary>
        /// <param name="vertices">Amount of vertices</param>
        public Graph(int vertices)
        {
            if (vertices < 0) {
                throw new ArgumentOutOfRangeException("No negative amount of vertices can exist");
            }
            edges = 0;
            adjacencyList = new List<List<int>>(vertices);
            addedEdges = new List<int[]>();
            for (int v = 0; v < vertices; v++)
            {
                AddVertex();
            }
        }

        private readonly List<List<int>> adjacencyList;
        private readonly List<int[]> addedEdges;
        private int edges;

        #region IGraph methods

        /// <summary>
        /// Total amount of vertices in this graph
        /// </summary>
        /// <returns>integer, amount of vertices</returns>
        public int Vertices() => adjacencyList.Count();

        /// <summary>
        /// Total amount of edges in this graph
        /// </summary>
        /// <returns>integer, amount of edges</returns>
        public int Edges() => edges;

        /// <summary>
        /// Adds a vertex to the graph
        /// </summary>
        /// <returns>id (int) of the added vertex</returns>
        public int AddVertex()
        {
            adjacencyList.Add(new List<int>());
            return adjacencyList.Count - 1;
        }

        /// <summary>
        /// Adds an edge from a vertex to another vertex (can be the same)
        /// </summary>
        /// <param name="vertexFrom">Id of vertex where the edge starts</param>
        /// <param name="vertexTo">Id of vertex where the edge ends</param>
        public void AddEdge(int vertexFrom, int vertexTo)
        {
            if (!GraphUtil.AreVerticesWithinBounds(this, vertexFrom, vertexTo))
            {
                throw new ArgumentOutOfRangeException($"Edge from {vertexFrom} to {vertexTo} is not possible. Max index is: {Vertices() - 1 }");
            }

            addedEdges.Add(new int[] { vertexFrom, vertexTo });
            adjacencyList[vertexFrom].Add(vertexTo);

            // add the edge the other way around; only if the edge is not a self-loop
            if (vertexFrom != vertexTo)
            {
                adjacencyList[vertexTo].Add(vertexFrom);
            }
            edges++;
        }

        /// <summary>
        /// Returns all vertices (id's) that are adjecent to this vertex
        /// </summary>
        /// <param name="vertex">id of vertex</param>
        /// <returns>List with ID's of connected vertices</returns>
        public IEnumerable<int> AdjacentVertices(int vertex) => adjacencyList[vertex];

        #endregion IGraph methods

        /// <summary>
        /// Creates a deepcopy of this graph
        /// </summary>
        /// <returns>Graph</returns>
        public Graph DeepCopy()
        {
            var copy = new Graph(Vertices());
            for (int e = 0; e < addedEdges.Count; e++)
            {
                copy.AddEdge(addedEdges[e][0], addedEdges[e][1]);
            }
            return copy;
        }

        /// <summary>
        /// Standard representation of the directed graph
        /// </summary>
        /// <returns></returns>
        public override string ToString() => GraphUtil.Stringify(this);



    }
}

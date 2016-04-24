using System.Collections.Generic;

namespace Fluttert.DirectGraph
{
    /// <summary>
    /// Interface for graphs
    /// </summary>
    public interface IGraph
    {
        /// <summary>
        /// The amount of vertices in this graph
        /// </summary>
        /// <returns>integer, amount of vertices</returns>
        int Vertices();

        /// <summary>
        /// The amount of edges in this graph
        /// </summary>
        /// <returns>integer</returns>
        int Edges();

        /// <summary>
        /// Adds a vertex
        /// </summary>
        /// <returns>Identifier of the added vertex</returns>
        int AddVertex();

        /// <summary>
        /// Adds an edge from a vertex to another vertex (can be the same)
        /// </summary>
        /// <param name="vertexFrom">Id of vertex where the edge starts</param>
        /// <param name="vertexTo">Id of vertex where the edge ends</param>
        void AddEdge(int vertexFrom, int vertexTo);

        /// <summary>
        /// Returns all vertices (id's) that are adjecent to this vertex
        /// </summary>
        /// <param name="vertex">id of vertex</param>
        /// <returns>List with ID's of connected vertices</returns>
        IEnumerable<int> AdjecentVertices(int vertex);
    }
}
using System.Text;

namespace Fluttert.DirectGraph
{
    internal class GraphUtil
    {
        /// <summary>
        /// Helper utility that generates an uniform string representation of the graph
        /// </summary>
        /// <param name="graph">The graph to be represented in string format (must implement IGraph)</param>
        /// <returns>string</returns>
        internal static string Stringify(IGraph graph)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{graph.Vertices()} vertices, {graph.Edges()} edges");
            for (int v = 0; v < graph.Vertices(); v++)
            {
                sb.AppendLine($"Vertex {v} connects to: {string.Join(" ", graph.AdjacentVertices(v))}");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Determine if a vertex is within bounds of a graph
        /// </summary>
        /// <param name="graph">The graph (instance of IGraph)</param>
        /// <param name="vertexId">The vertex-id to be checked (int)</param>
        /// <returns>bool</returns>
        internal static bool IsVertexWithinBounds(IGraph graph, int vertexId)
        {
            return vertexId >= 0 && vertexId < graph.Vertices();
        }

        /// <summary>
        /// Determine if 2 vertices are within the bound of a graph (for edges)
        /// </summary>
        /// <param name="graph">The graph (instance of IGraph)</param>
        /// <param name="vertexId1">Vertex-id to be checked</param>
        /// <param name="vertexId2">Vertex-id to be checked</param>
        /// <returns>bool</returns>
        internal static bool AreVerticesWithinBounds(IGraph graph, int vertexId1, int vertexId2)
        {
            return IsVertexWithinBounds(graph, vertexId1) && IsVertexWithinBounds(graph, vertexId2);
        }
    }
}
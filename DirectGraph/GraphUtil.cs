using System.Text;

namespace Fluttert.DirectGraph
{
    internal class GraphUtil
    {
        internal static string Stringify(IGraph graph)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{graph.Vertices()} vertices, {graph.Edges()} edges");
            for (int v = 0; v < graph.Vertices(); v++)
            {
                sb.AppendLine($"Vertex {v} connects to: {string.Join(" ", graph.AdjecentVertices(v))}");
            }
            return sb.ToString();
        }
    }
}
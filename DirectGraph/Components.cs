using System.Collections.Generic;

namespace Fluttert.DirectGraph
{
    public class Components
    {
        public int[] ConnectedComponents(Graph graph)
        {
            int[] componentIds = new int[graph.Vertices()];
            bool[] marked = new bool[graph.Vertices()];
            int currentComponentId = 0;

            for (int v = 0; v < graph.Vertices(); v++)
            {
                // skip the vertices that we already processed
                if (marked[v]) { continue; }

                // do a Breadth First Search from this starting vertex
                var queue = new Queue<int>();
                queue.Enqueue(v);
                while (queue.Count > 0) {
                    int vertex = queue.Dequeue();
                    marked[v] = true;
                    componentIds[v] = currentComponentId;
                    foreach (int adjacentVertex in graph.AdjacentVertices(v)) {
                        queue.Enqueue(adjacentVertex);
                    }
                }

                // no more connected vertices;
                // next vertex will have another componentId
                currentComponentId++;
            }

            return componentIds;
        }
    }
}
using System.Collections.Generic;

namespace Fluttert.DirectGraph
{
    /// <summary>
    /// Calculates which vertices are connected with each other,
    /// this is called a Connected Component within a graph
    /// </summary>
    public class ConnectedComponents
    {
        private int amountOfComponents;
        private int[] componentIds;

        /// <summary>
        /// Construct the connected components based on an undirected graph
        /// </summary>
        /// <param name="graph"></param>
        public ConnectedComponents(UndirectedGraph graph)
        {
            componentIds = new int[graph.Vertices()];
            amountOfComponents = 0;
        }

        public int ComponentId(int vertex) => componentIds[vertex];

        public int AmountOfComponents() => amountOfComponents;

        public bool Connected(int vertex1, int vertex2) => ComponentId(vertex1) == ComponentId(vertex2);

        public List<int> GetVerticesForComponent(int componentId) {
            var result = new List<int>();
            for (int i = 0; i < componentIds.Length; i++) {
                if (componentIds[i] == componentId)
                {
                    result.Add(i);
                }
            }
            return result;
        }


        private void ProcessGraph(UndirectedGraph graph)
        {
            int currentComponentId = 0;
            bool[] marked = new bool[graph.Vertices()];

            // make sure ALL vertices are added at least once
            for (int v = 0; v < graph.Vertices(); v++)
            {
                // skip the vertices that we already processed
                if (marked[v]) { continue; }

                // do a Breadth First Search from this starting vertex
                var queue = new Queue<int>();
                queue.Enqueue(v);
                while (queue.Count > 0)
                {
                    int vertex = queue.Dequeue();
                    marked[v] = true;
                    componentIds[v] = currentComponentId;
                    foreach (int adjacentVertex in graph.AdjacentVertices(v))
                    {
                        if (!marked[v])
                        {
                            queue.Enqueue(adjacentVertex);
                        }
                    }
                }
                // no more connected vertices;
                // next vertex will have another componentId
                currentComponentId++;
                amountOfComponents++;
            }
        }
    }
}
using System;
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
        private int vertices;

        /// <summary>
        /// Construct the connected components based on an undirected graph
        /// </summary>
        /// <param name="graph">Graph to be examined</param>
        public ConnectedComponents(UndirectedGraph graph)
        {
            componentIds = new int[graph.Vertices()];
            amountOfComponents = 0;
            vertices = graph.Vertices();
        }

        /// <summary>
        /// Based a vertex give back the corresponding Component ID
        /// </summary>
        /// <param name="vertex">The vertexId in the graph</param>
        /// <returns>int, component ID</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when vertex is out of range</exception>
        public int ComponentId(int vertex)
        {
            if (vertex < 0 || vertex >= vertices)
            {
                throw new ArgumentOutOfRangeException($"vertex id {vertex} is out of range. Range is: 0 -  {vertices - 1 }");
            }
            return componentIds[vertex];
        }

        /// <summary>
        /// Total amount of components for this graph
        /// </summary>
        /// <returns>int</returns>
        public int AmountOfComponents() => amountOfComponents;

        /// <summary>
        /// Dertermine if 2 vertices are in the same connected component
        /// </summary>
        /// <param name="vertex1">ID of vertex 1</param>
        /// <param name="vertex2">ID of vertex 2</param>
        /// <returns>bool: true on connected, false otherwise</returns>
        public bool Connected(int vertex1, int vertex2) => ComponentId(vertex1) == ComponentId(vertex2);

        /// <summary>
        /// Given a component ID, return all vertices
        /// </summary>
        /// <param name="componentId">The component ID</param>
        /// <returns>List of integers with the vertices belonging to this component</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when componentId does not exist</exception>
        public List<int> GetVerticesForComponent(int componentId)
        {
            if (componentId < 0 || componentId >= amountOfComponents)
            {
                throw new ArgumentOutOfRangeException($"componentid {componentId} is out of range. Range is: 0 -  {amountOfComponents - 1 }");
            }

            var result = new List<int>();
            for (int i = 0; i < componentIds.Length; i++)
            {
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
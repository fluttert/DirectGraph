using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fluttert.DirectGraph;
using System.Linq;

namespace Fluttert.DirectGraphTests
{
    [TestClass]
    public class DirectedGraphTests
    {
        [TestMethod]
        public void CreateDirectedGraph()
        {
            // a cube
            var graph = new DirectedGraph(4);
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 0);

            Assert.AreEqual(4, graph.Vertices());
            Assert.AreEqual(4, graph.Edges());
            Assert.IsTrue(graph.AdjacentVertices(0).Contains(1));
            Assert.IsTrue(graph.AdjacentVertices(1).Contains(2));
            Assert.IsTrue(graph.AdjacentVertices(2).Contains(3));
            Assert.IsTrue(graph.AdjacentVertices(3).Contains(0));

            // no linkback
            Assert.IsFalse(graph.AdjacentVertices(0).Contains(3));
        }

        [TestMethod]
        public void CreateEmptyDirectedGraphAndAddVertices()
        {
            var graph = new DirectedGraph();
            Assert.AreEqual(0, graph.Vertices());
            Assert.AreEqual(0, graph.Edges());

            int vertex1id = graph.AddVertex();
            int vertex2id = graph.AddVertex();
            Assert.AreEqual(0, vertex1id);
            Assert.AreEqual(1, vertex2id);

            graph.AddEdge(0, 1);
            Assert.AreEqual(2, graph.Vertices());
            Assert.AreEqual(1, graph.Edges());
            Assert.IsTrue(graph.AdjacentVertices(0).Contains(1));
            Assert.IsFalse(graph.AdjacentVertices(1).Contains(0));

            // add the same edge again
            graph.AddEdge(1, 0);
            Assert.AreEqual(2, graph.Vertices());
            Assert.AreEqual(2, graph.Edges());
            Assert.IsTrue(graph.AdjacentVertices(0).Contains(1));
            Assert.IsTrue(graph.AdjacentVertices(1).Contains(0));
        }

        [TestMethod]
        public void CreateDirectedGraphWithSelfLoops()
        {
            var graph = new DirectedGraph(1);
            Assert.AreEqual(1, graph.Vertices());
            Assert.AreEqual(0, graph.Edges());

            graph.AddEdge(0, 0);
            Assert.AreEqual(1, graph.Edges());
            Assert.IsTrue(graph.AdjacentVertices(0).Contains(0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateInvalidDirectedGraphWithNegativeAmountOfVertices()
        {
            var graph = new DirectedGraph(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DirectedGraphAddInvalidEdge()
        {
            var graph = new DirectedGraph(2);
            graph.AddEdge(0, 10);
        }

        [TestMethod]
        public void DeepCopyDirectedGraph()
        {
            // a cube
            var graph = new DirectedGraph(4);
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 0);
            graph.AddEdge(0, 2);
            
            var graph2 = graph.DeepCopy();

            Assert.AreEqual(graph.ToString(), graph2.ToString());
            Assert.AreNotSame(graph, graph2);

            graph.AddEdge(3, 3);
            Assert.AreNotEqual(graph.ToString(), graph2.ToString());
            Assert.AreNotSame(graph, graph2);
        }
    }
}

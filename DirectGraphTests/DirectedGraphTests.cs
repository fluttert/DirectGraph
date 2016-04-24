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
        public void CreateGraph()
        {
            // a cube
            var graph = new DirectedGraph(4);
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 0);
            graph.AddEdge(0, 2);
            graph.AddEdge(3, 3);

            Assert.AreEqual(4, graph.Vertices());
            Assert.AreEqual(6, graph.Edges());
            Assert.IsTrue(graph.AdjecentVertices(0).Contains(1));
            Assert.IsTrue(graph.AdjecentVertices(2).Contains(3));
            Assert.IsTrue(graph.AdjecentVertices(3).Contains(3));
            Assert.IsFalse(graph.AdjecentVertices(1).Contains(0));
            Assert.IsFalse(graph.AdjecentVertices(2).Contains(0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateInvalidGraphWithNegativeAmountOfVertices()
        {
            var graph = new DirectedGraph(-1);
        }

        [TestMethod]
        public void DeepCopyGraph()
        {
            // a cube
            var graph = new DirectedGraph(4);
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 0);
            graph.AddEdge(0, 2);
            graph.AddEdge(3, 3);

            var graph2 = graph.DeepCopy();

            Assert.AreEqual(graph.ToString(), graph2.ToString());
            Assert.AreNotSame(graph, graph2);
        }
    }
}

using Fluttert.DirectGraph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Fluttert.DirectGraphTests
{
    [TestClass]
    public class GraphsTests
    {
        [TestMethod]
        public void CreateGraph()
        {
            // a cube
            var graph = new Graph(4);
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 0);
            
            Assert.AreEqual(4, graph.Vertices());
            Assert.AreEqual(6, graph.Edges());
            Assert.IsTrue(graph.AdjecentVertices(0).Contains(1));
            Assert.IsTrue(graph.AdjecentVertices(2).Contains(3));
            Assert.IsTrue(graph.AdjecentVertices(3).Contains(3));
            Assert.IsTrue(graph.AdjecentVertices(1).Contains(0));
            Assert.IsTrue(graph.AdjecentVertices(2).Contains(0));
            Assert.IsFalse(graph.AdjecentVertices(1).Contains(3));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateInvalidGraphWithNegativeAmountOfVertices() {
            var graph = new Graph(-1);
        }

        [TestMethod]
        public void DeepCopyGraph()
        {
            // a cube
            var graph = new Graph(4);
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 0);
            graph.AddEdge(3, 3);

            var graph2 = graph.DeepCopy();

            Assert.AreEqual(graph.ToString(), graph2.ToString());
            Assert.AreNotSame(graph, graph2);

            graph.AddEdge(0, 2);
            Assert.AreNotEqual(graph.ToString(), graph2.ToString());
            Assert.AreNotSame(graph, graph2);
        }
    }
}
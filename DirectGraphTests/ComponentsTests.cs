using Fluttert.DirectGraph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Fluttert.DirectGraphTests
{
    [TestClass]
    public class ComponentsTests
    {
        public static UndirectedGraph graph;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            /* C0: 0 1 2 3 4 5 6
            *  C1: 7 8
            *  C2: 9 10 11 12
            */

            graph = new UndirectedGraph(13);
            graph.AddEdge(0, 5);
            graph.AddEdge(4, 3);
            graph.AddEdge(0, 1);
            graph.AddEdge(9, 12);
            graph.AddEdge(6, 4);
            graph.AddEdge(5, 4);
            graph.AddEdge(0, 2);
            graph.AddEdge(11, 12);
            graph.AddEdge(9, 10);
            graph.AddEdge(0, 6);
            graph.AddEdge(7, 8);
            graph.AddEdge(9, 11);
            graph.AddEdge(5, 3);
        }

        [TestMethod]
        public void GraphConnectedComponentsEmpty()
        {
            var graph = new UndirectedGraph();
            var cc = new ConnectedComponents(graph);

            Assert.AreEqual(0, cc.AmountOfComponents);
        }

        [TestMethod]
        public void GraphConnectedComponentsSelfLoop()
        {
            var graph = new UndirectedGraph(1);
            graph.AddEdge(0, 0);
            var cc = new ConnectedComponents(graph);
            Assert.AreEqual(1, cc.AmountOfComponents);
            Assert.AreEqual(0, cc.ComponentId(0));
            Assert.IsTrue(cc.Connected(0, 0));
        }

        [TestMethod]
        public void GraphConnectedComponents()
        {
            var g = graph.DeepCopy();
            var cc = new ConnectedComponents(g);

            Assert.AreEqual(3, cc.AmountOfComponents);
            Assert.IsTrue(cc.Connected(0, 1));
            Assert.IsTrue(cc.Connected(7, 8));
            Assert.IsTrue(cc.Connected(9, 12));
            CollectionAssert.AreEqual(new List<int>() { 7, 8 }, cc.GetVerticesForComponent(1));
        }

        [TestMethod]
        public void GraphConnectedComponents2()
        {
            var g = graph.DeepCopy();
            g.AddEdge(6, 7);
            var cc = new ConnectedComponents(g);

            Assert.AreEqual(2, cc.AmountOfComponents);
            Assert.IsTrue(cc.Connected(0, 1));
            Assert.IsTrue(cc.Connected(0, 8));
            Assert.IsTrue(cc.Connected(9, 12));
            CollectionAssert.AreNotEqual(new List<int>() { 7, 8 }, cc.GetVerticesForComponent(1));
        }
    }
}
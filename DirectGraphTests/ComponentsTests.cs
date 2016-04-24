using Fluttert.DirectGraph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluttert.DirectGraphTests
{
    [TestClass]
    class ComponentsTests
    {
        protected static Graph graph;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            graph = new Graph(5);
            graph.AddEdge(0, 1);
            graph.AddEdge(2, 3);
        }


        [TestMethod]
        public void GraphConnectedComponents() {
            var g = graph.DeepCopy();

            //int[] components = 
        }
    }
}

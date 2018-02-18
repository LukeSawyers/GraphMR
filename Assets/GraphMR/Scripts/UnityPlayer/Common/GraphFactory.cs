using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraphMR
{
    /// <summary>
    /// Class for creating graphs used by the GraphManager
    /// </summary>
    public class GraphFactory : MonoBehaviour
    {
        /// <summary>
        /// Creates a new empty graph
        /// </summary>
        /// <returns></returns>
        public static Graph CreateGraph()
        {
            return CreateGraph(new SerializableGraph("New Graph", new List<SerializableNode>(), new List<SerializableConnector>()));
        }

        /// <summary>
        /// Creates a graph from the serialized data given
        /// </summary>
        /// <param name="serializedGraph"></param>
        /// <returns></returns>
        public static Graph CreateGraph(SerializableGraph serializedGraph)
        {
            GameObject GraphObj = new GameObject(serializedGraph.graphName + " root object");

            // create the graph
            var graph = GraphObj.AddComponent<Graph>();
            graph.GraphName = serializedGraph.graphName;
            graph.InitialiseGraph(serializedGraph);

            return graph;
        }
    }
}
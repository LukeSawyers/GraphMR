using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraphMR
{
    /// <summary>
    /// A factory class for creating and saving node objects
    /// </summary>
    public class NodeFactory : MonoBehaviour
    {
        /// <summary>
        /// A dictionary of all nodes referenced by their Guids
        /// </summary>
        public Dictionary<Guid,Node> Nodes = new Dictionary<Guid,Node>();

        private Graph _graph;

        /// <summary>
        /// Returns a unique id for a node based on the nodes that already exist
        /// </summary>
        /// <returns></returns>
        public Guid GetUniqueID()
        {
            Guid result = Guid.NewGuid();
            while (Nodes.ContainsKey(result))
            {
                result = Guid.NewGuid();
            }
            return result;
        }

        /// <summary>
        /// Creates a new node 
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public Node CreateNode(Graph graph, SerializableNode serializedNode)
        {
            GameObject newNodeObj = new GameObject("Node - " + serializedNode.name);
            newNodeObj.transform.parent = graph.transform;
            Node newNode = newNodeObj.AddComponent<Node>();
            newNode.name = serializedNode.name;
            newNode.un
        }

        private void Awake()
        {
            Nodes = new Dictionary<Guid, Node>();
        }
    }
}
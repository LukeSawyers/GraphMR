using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraphMR
{
    /// <summary>
    /// A factory class for creating and saving node objects
    /// </summary>
    public static class NodeFactory
    {
        /// <summary>
        /// Creates a new blank node
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static Node CreateNode(Graph graph)
        {
            GameObject newNodeObj = new GameObject("Node - New Node");
            newNodeObj.transform.parent = graph.transform;

            Node newNode = newNodeObj.AddComponent<Node>();
            newNode.name = "New Node";
            newNode.UniqueID = graph.GetUniqueID();
            newNode.Tags = new List<string>();

            return newNode;
        }

        /// <summary>
        /// Creates a node from a serialized node 
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static Node CreateNode(Graph graph, SerializableNode serializedNode)
        {
            GameObject newNodeObj = new GameObject("Node - " + serializedNode.name);
            newNodeObj.transform.parent = graph.transform;

            Node newNode = newNodeObj.AddComponent<Node>();
            newNode.name = serializedNode.name;
            newNode.UniqueID = serializedNode.uniqueID;
            newNode.Tags = serializedNode.tags;

            return newNode;
        }
    }
}
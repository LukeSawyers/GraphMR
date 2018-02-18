﻿using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraphMR
{
    /// <summary>
    /// A factory class for creating and saving node objects
    /// </summary>
    public class NodeFactory : MonoBehaviourSingleton<NodeFactory>
    {
        /// <summary>
        /// The list of available connector types
        /// </summary>
        public static List<string> NodeTypeNames
        {
            get
            {
                return Instance._nodeTypes.Select(n => n.NodeTypeName).ToList();
            }
        }

        private List<NodeType> _nodeTypes = new List<NodeType>();

        /// <summary>
        /// Creates a new blank node
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static Node CreateNode(Graph graph, string nodeType)
        {

            GameObject newNodeObj = Instantiate(Instance._nodeTypes.Single(n => n.NodeTypeName == nodeType).NodeObject);
            newNodeObj.transform.parent = graph.transform;

            Node newNode = newNodeObj.AddComponent<Node>();
            newNode.name = "New Node";
            newNode.UniqueID = graph.GetUniqueID();
            newNode.NodeType = nodeType;

            return newNode;
        }

        /// <summary>
        /// Creates a node from a serialized node 
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static Node CreateNode(Graph graph, SerializableNode serializedNode)
        {
            GameObject newNodeObj = Instantiate(Instance._nodeTypes.Single(n => n.NodeTypeName == serializedNode.type).NodeObject);
            newNodeObj.transform.parent = graph.transform;

            Node newNode = newNodeObj.AddComponent<Node>();
            newNode.name = serializedNode.name;
            newNode.UniqueID = serializedNode.uniqueID;
            newNode.NodeType = serializedNode.type;

            return newNode;
        }
    }
}
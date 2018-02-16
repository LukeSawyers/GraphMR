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
        public static Dictionary<Guid,Node> Nodes = new Dictionary<Guid,Node>();

        /// <summary>
        /// Returns a unique id for a node based on the nodes that already exist
        /// </summary>
        /// <returns></returns>
        public static Guid GetUniqueID()
        {
            Guid result = Guid.NewGuid();
            while (Nodes.ContainsKey(result))
            {
                result = Guid.NewGuid();
            }
            return result;
        }

        private void Awake()
        {
            Nodes = new Dictionary<Guid, Node>();
        }
    }
}
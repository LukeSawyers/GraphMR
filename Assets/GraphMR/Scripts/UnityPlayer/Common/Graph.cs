using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraphMR
{
    /// <summary>
    /// Represents a complete graph
    /// </summary>
    [DisallowMultipleComponent]
    public class Graph : MonoBehaviour
    {
        /// <summary>
        /// A dictionary of all nodes referenced by their Guids
        /// </summary>
        public Dictionary<Guid, Node> Nodes
        {
            get
            {
                return _nodes;
            }
        }

        /// <summary>
        /// A dictionary of all nodes referenced by their Guids
        /// </summary>
        public List<Connector> Connectors
        {
            get
            {
                return _connectors;
            }
        }

        /// <summary>
        /// The name of this graph
        /// </summary>
        public string GraphName
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        private string _name = "Untitled";

        private Dictionary<Guid, Node> _nodes = new Dictionary<Guid, Node>();

        private List<Connector> _connectors = new List<Connector>();

        private bool _initialised = false;

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
        /// Initialises this graph with a serializable graph
        /// </summary>
        /// <param name="serialized"></param>
        public void InitialiseGraph(SerializableGraph serialized)
        {
            if (_initialised)
            {
                throw new System.Exception("Trying to use 'Initialise Graph' on an already initialized graph");
            }

            StartCoroutine(PopulateGraph(serialized));

            _initialised = true;

        }

        /// <summary>
        /// Coroutine that progressively creates nodes and the connects them
        /// </summary>
        /// <param name="serialized"></param>
        /// <returns></returns>
        private IEnumerator PopulateGraph(SerializableGraph serialized)
        {
            // create nodes
            var nodes = serialized.nodes;
            foreach(var node in nodes)
            {
                var newNode = NodeFactory.CreateNode(this, node);
                _nodes.Add(newNode.UniqueID, newNode);
            }

            // create connectors
            var connectors = serialized.connectors;
            foreach(var connector in connectors)
            {
                var newConnector = ConnectorFactory.CreateConnector(this, connector);
            }


            yield return null;
        }

        /// <summary>
        /// Creates a serializable version of this object
        /// </summary>
        /// <returns></returns>
        public SerializableGraph ToSerializable()
        {
            List<SerializableNode> sNodes = _nodes.Values.Select(n => n.ToSerializable()).ToList();
            List<SerializableConnector> sConnectors = _connectors.Select(c => c.ToSerializable()).ToList();
            return new SerializableGraph(_name, sNodes, sConnectors);
        }
    }

    /// <summary>
    /// A serializable version of a graph
    /// </summary>
    [System.Serializable]
    public struct SerializableGraph
    {

        public SerializableGraph(string graphName, List<SerializableNode> nodes, List<SerializableConnector> connectors)
        {
            this.graphName = graphName;
            this.nodes = nodes;
            this.connectors = connectors;
        }

        public string graphName;
        public List<SerializableNode> nodes;
        public List<SerializableConnector> connectors;
    }
}


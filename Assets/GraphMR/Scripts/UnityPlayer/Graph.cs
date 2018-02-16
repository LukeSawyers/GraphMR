using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraphMR
{
    /// <summary>
    /// Represents a complete graph
    /// </summary>
    [RequireComponent(typeof(ConnectorFactory))]
    [RequireComponent(typeof(NodeFactory))]
    public class Graph : MonoBehaviour
    {
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

        public ConnectorFactory GraphConnectorFactory
        {
            get
            {
                if(_connectorFactory == null)
                {
                    _connectorFactory = GetComponent<ConnectorFactory>();
                }
                return _connectorFactory;
            }
        }

        public NodeFactory GraphNodeFactory
        {
            get
            {
                if (_nodeFactory == null)
                {
                    _nodeFactory = GetComponent<NodeFactory>();
                }
                return _nodeFactory;
            }
        }

        private string _name = "Untitled";

        private ConnectorFactory _connectorFactory;

        private NodeFactory _nodeFactory;

        private List<Node> _nodes = new List<Node>();

        private List<Connector> _connectors = new List<Connector>();

        private bool _initialised = false;

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
        public IEnumerator PopulateGraph(SerializableGraph serialized)
        {
            // create nodes
            var nodes = serialized.nodes;
            foreach(var node in nodes)
            {

            }

            yield return null;
        }

        public SerializableGraph ToSerializable()
        {
            List<SerializableNode> sNodes = _nodes.Select(n => n.ToSerializable()).ToList();
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


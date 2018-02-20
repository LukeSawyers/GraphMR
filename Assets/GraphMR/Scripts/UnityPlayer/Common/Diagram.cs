using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiagramMR
{
    /// <summary>
    /// Represents a complete diagram
    /// </summary>
    [DisallowMultipleComponent]
    public class Diagram : MonoBehaviour
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
        /// The name of this diagram
        /// </summary>
        public string diagramName
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
        /// Initialises this diagram with a serializable diagram
        /// </summary>
        /// <param name="serialized"></param>
        public void Initialisediagram(Serializablediagram serialized)
        {
            if (_initialised)
            {
                throw new System.Exception("Trying to use 'Initialise diagram' on an already initialized diagram");
            }

            StartCoroutine(Populatediagram(serialized));

            _initialised = true;

        }

        /// <summary>
        /// Coroutine that progressively creates nodes and the connects them
        /// </summary>
        /// <param name="serialized"></param>
        /// <returns></returns>
        private IEnumerator Populatediagram(Serializablediagram serialized)
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
        public Serializablediagram ToSerializable()
        {
            List<SerializableNode> sNodes = _nodes.Values.Select(n => n.ToSerializable()).ToList();
            List<SerializableConnector> sConnectors = _connectors.Select(c => c.ToSerializable()).ToList();
            return new Serializablediagram(_name, sNodes, sConnectors);
        }
    }

    /// <summary>
    /// A serializable version of a diagram
    /// </summary>
    [System.Serializable]
    public struct Serializablediagram
    {

        public Serializablediagram(string diagramName, List<SerializableNode> nodes, List<SerializableConnector> connectors)
        {
            this.diagramName = diagramName;
            this.nodes = nodes;
            this.connectors = connectors;
        }

        public string diagramName;
        public List<SerializableNode> nodes;
        public List<SerializableConnector> connectors;
    }
}


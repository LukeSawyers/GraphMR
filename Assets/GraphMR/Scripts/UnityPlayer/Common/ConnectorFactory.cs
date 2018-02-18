using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace diagramMR
{
    /// <summary>
    /// Connector factory singleton produces connectors
    /// </summary>
    [DisallowMultipleComponent]
    public class ConnectorFactory : MonoBehaviour
    {
        /// <summary>
        /// The list of available connector types
        /// </summary>
        public List<string> ConnectorTypeNames
        {
            get
            {
                return _connectorTypes.Select(c => c.ConnectorTypeName).ToList();
            }
        }

        private List<ConnectorType> _connectorTypes = new List<ConnectorType>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="diagram"></param>
        /// <param name="originNode"></param>
        /// <returns></returns>
        public static Connector CreateConnector(Diagram diagram, string connectorType)
        {
            GameObject newConnectorObj = new GameObject("Connector - New Node");
            newConnectorObj.transform.parent = diagram.transform;

            Connector newConnector = newConnectorObj.AddComponent<Connector>();
            newConnector.name = "New Connector";

            return newConnector;
        }

        /// <summary>
        /// Creates a connector in the given diagram using a serialized connector. This diagram should already have its nodes created. 
        /// </summary>
        /// <param name="diagram"></param>
        /// <param name="originNode"></param>
        /// <returns></returns>
        public static Connector CreateConnector(Diagram diagram, SerializableConnector serializedConnector)
        {
            GameObject newConnectorObj = new GameObject("Connector - New Node");
            newConnectorObj.transform.parent = diagram.transform;

            Connector newConnector = newConnectorObj.AddComponent<Connector>();

            // add origin node
            if(serializedConnector.originNodeID != null)
            {
                if (diagram.Nodes.ContainsKey(serializedConnector.originNodeID))
                {
                    var originNode = diagram.Nodes[serializedConnector.originNodeID];
                    newConnector.OriginNode = originNode;
                }
            }

            // add end node
            if (serializedConnector.endNodeID != null)
            {
                if (diagram.Nodes.ContainsKey(serializedConnector.endNodeID))
                {
                    var endNode = diagram.Nodes[serializedConnector.endNodeID];
                    newConnector.EndNode = endNode;
                }
            }

            return newConnector;
        }
    }
}
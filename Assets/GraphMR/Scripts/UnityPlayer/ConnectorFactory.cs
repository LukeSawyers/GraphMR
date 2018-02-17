using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraphMR
{
    /// <summary>
    /// Connector factory singleton produces connectors
    /// </summary>
    public static class ConnectorFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="originNode"></param>
        /// <returns></returns>
        public static Connector CreateConnector(Graph graph)
        {
            GameObject newConnectorObj = new GameObject("Connector - New Node");
            newConnectorObj.transform.parent = graph.transform;

            Connector newConnector = newConnectorObj.AddComponent<Connector>();
            newConnector.name = "New Connector";

            return newConnector;
        }

        /// <summary>
        /// Creates a connector in the given graph using a serialized connector. This graph should already have its nodes created. 
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="originNode"></param>
        /// <returns></returns>
        public static Connector CreateConnector(Graph graph, SerializableConnector serializedConnector)
        {
            GameObject newConnectorObj = new GameObject("Connector - New Node");
            newConnectorObj.transform.parent = graph.transform;

            Connector newConnector = newConnectorObj.AddComponent<Connector>();

            // add origin node
            if(serializedConnector.originNodeID != null)
            {
                if (graph.Nodes.ContainsKey(serializedConnector.originNodeID))
                {
                    var originNode = graph.Nodes[serializedConnector.originNodeID];
                    newConnector.OriginNode = originNode;
                }
            }

            // add end node
            if (serializedConnector.endNodeID != null)
            {
                if (graph.Nodes.ContainsKey(serializedConnector.endNodeID))
                {
                    var endNode = graph.Nodes[serializedConnector.endNodeID];
                    newConnector.EndNode = endNode;
                }
            }

            return newConnector;
        }
    }
}
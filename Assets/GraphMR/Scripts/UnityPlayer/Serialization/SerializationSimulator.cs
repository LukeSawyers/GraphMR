using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraphMR
{
    public class SerializationSimulator : MonoBehaviour, IGraphSerializer
    {
        /// <summary>
        /// Returns an empty list since there will never be files to load
        /// </summary>
        public List<string> FileNames
        {
            get
            {
                return new List<string>();
            }
        }

        public string Identifier
        {
            get
            {
                return "Simulator";
            }
        }

        public bool Read
        {
            get
            {
                return true;
            }
        }

        public bool Write
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Manufactures a random graph
        /// </summary>
        /// <param name="graphName"></param>
        /// <returns></returns>
        public SerializableGraph LoadGraph(string graphName)
        {
            // create a random graph
            var numberOfNodes = Random.Range(10, 40);
            var numberOfConnectors = Random.Range(numberOfNodes * 2, numberOfNodes * 5);
            var nodeList = new List<SerializableNode>();

            for(int i = 0; i < numberOfNodes; i++)
            {
                var newNode = new SerializableNode(NodeFactory.GetUniqueID(), i.ToString(), new List<string>(), Color.blue);
                nodeList.Add(newNode);
            }

            var connectorList = new List<SerializableConnector>();

            for (int i = 0; i < numberOfConnectors; i++)
            {
                var nodeInd = Random.Range(0, numberOfNodes);
                var originNode = nodeList[nodeInd];

                nodeInd = Random.Range(0, numberOfNodes);
                var endNode = nodeList[nodeInd];

                var newConnector = new SerializableConnector(originNode.uniqueID, endNode.uniqueID);
                connectorList.Add(newConnector);
            }

            var sGraph = new SerializableGraph("Random Graph", nodeList, connectorList);
            return sGraph;
        }

        /// <summary>
        /// This will throw an exception as graphs cannot be saved with this serializer
        /// </summary>
        /// <param name="graph"></param>
        public void SaveGraph(SerializableGraph graph)
        {
            throw new System.Exception("This serializer cannot save files");
        }
    }
}


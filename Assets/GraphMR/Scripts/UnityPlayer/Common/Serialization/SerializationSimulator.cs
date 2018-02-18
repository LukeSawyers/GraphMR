using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraphMR
{
    [DisallowMultipleComponent]
    public class SerializationSimulator : MonoBehaviour, IGraphSerializer
    {
        /// <summary>
        /// Returns all graphs that have been saved in this session
        /// </summary>
        List<string> IGraphSerializer.FileNames
        {
            get
            {
                return _savedGraphs.Select(s => s.graphName).ToList();
            }
        }

        string IGraphSerializer.Identifier
        {
            get
            {
                return "SIM";
            }
        }

        private List<SerializableGraph> _savedGraphs = new List<SerializableGraph>();

        /// <summary>
        /// Manufactures a random graph
        /// </summary>
        /// <param name="graphName"></param>
        /// <returns></returns>
        SerializableGraph IGraphSerializer.LoadGraph(string graphName)
        {
            var graph = _savedGraphs.SingleOrDefault(s => s.graphName == graphName);

            return graph;

            // create a random graph
            var numberOfNodes = UnityEngine.Random.Range(10, 40);
            var numberOfConnectors = UnityEngine.Random.Range(numberOfNodes * 2, numberOfNodes * 5);
            var nodeList = new List<SerializableNode>();

            for(int i = 0; i < numberOfNodes; i++)
            {
                var newNode = new SerializableNode(Guid.NewGuid(), i.ToString(), "", Color.blue);
                nodeList.Add(newNode);
            }

            var connectorList = new List<SerializableConnector>();

            for (int i = 0; i < numberOfConnectors; i++)
            {
                var nodeInd = UnityEngine.Random.Range(0, numberOfNodes);
                var originNode = nodeList[nodeInd];

                nodeInd = UnityEngine.Random.Range(0, numberOfNodes);
                var endNode = nodeList[nodeInd];

                var newConnector = new SerializableConnector(originNode.uniqueID, endNode.uniqueID);
                connectorList.Add(newConnector);
            }

            var sGraph = new SerializableGraph("Random Graph - " + Guid.NewGuid().ToString(), nodeList, connectorList);
            return sGraph;
        }

        /// <summary>
        /// Saves a graph, this will only last for this session
        /// </summary>
        /// <param name="graph"></param>
        void IGraphSerializer.SaveGraph(SerializableGraph graph)
        {
            _savedGraphs.Add(graph);
        }
    }
}


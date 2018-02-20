using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiagramMR
{
    [DisallowMultipleComponent]
    public class SerializationSimulator : MonoBehaviour, IdiagramSerializer
    {
        /// <summary>
        /// Returns all diagrams that have been saved in this session
        /// </summary>
        List<string> IdiagramSerializer.FileNames
        {
            get
            {
                return _saveddiagrams.Select(s => s.diagramName).ToList();
            }
        }

        string IdiagramSerializer.Identifier
        {
            get
            {
                return "SIM";
            }
        }

        private List<Serializablediagram> _saveddiagrams = new List<Serializablediagram>();

        /// <summary>
        /// Manufactures a random diagram
        /// </summary>
        /// <param name="diagramName"></param>
        /// <returns></returns>
        Serializablediagram IdiagramSerializer.Loaddiagram(string diagramName)
        {
            var diagram = _saveddiagrams.SingleOrDefault(s => s.diagramName == diagramName);

            return diagram;

            // create a random diagram
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

            var sdiagram = new Serializablediagram("Random diagram - " + Guid.NewGuid().ToString(), nodeList, connectorList);
            return sdiagram;
        }

        /// <summary>
        /// Saves a diagram, this will only last for this session
        /// </summary>
        /// <param name="diagram"></param>
        void IdiagramSerializer.Savediagram(Serializablediagram diagram)
        {
            _saveddiagrams.Add(diagram);
        }
    }
}


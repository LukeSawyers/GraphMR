using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraphMR
{
    public class ConnectorFactory : MonoBehaviour
    {
        public static List<Connector> Connectors = new List<Connector>();

        // Use this for initialization
        private void Awake()
        {
            Connectors = new List<Connector>();
        }
    }
}
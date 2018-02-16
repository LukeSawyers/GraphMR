using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraphMR
{
    public class Graph : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    [System.Serializable]
    public struct SerializableGraph
    {
        public List<SerializableNode> nodes;
    }
}


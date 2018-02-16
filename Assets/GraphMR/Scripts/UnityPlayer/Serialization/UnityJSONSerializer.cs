using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraphMR.Serialization
{
    public class UnityJSONSerializer : MonoBehaviour, IGraphSerializer
    {
        public List<string> FileNames
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public string Identifier
        {
            get
            {
                return "JSON";
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
                return true;
            }
        }

        public SerializableGraph LoadGraph(string graphName)
        {
            throw new System.NotImplementedException();
        }

        public void SaveGraph(SerializableGraph graph)
        {
            throw new System.NotImplementedException();
        }
    }
}

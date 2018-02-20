using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiagramMR.Serialization
{
    public class UnityJSONSerializer : MonoBehaviour, IdiagramSerializer
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

        public Serializablediagram Loaddiagram(string diagramName)
        {
            throw new System.NotImplementedException();
        }

        public void Savediagram(Serializablediagram diagram)
        {
            throw new System.NotImplementedException();
        }
    }
}

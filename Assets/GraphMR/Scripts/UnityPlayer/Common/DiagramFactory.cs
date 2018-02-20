using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiagramMR
{
    /// <summary>
    /// Class for creating diagrams used by the diagramManager
    /// </summary>
    public class DiagramFactory : MonoBehaviour
    {
        /// <summary>
        /// Creates a new empty diagram
        /// </summary>
        /// <returns></returns>
        public static Diagram Creatediagram()
        {
            return Creatediagram(new Serializablediagram("New diagram", new List<SerializableNode>(), new List<SerializableConnector>()));
        }

        /// <summary>
        /// Creates a diagram from the serialized data given
        /// </summary>
        /// <param name="serializeddiagram"></param>
        /// <returns></returns>
        public static Diagram Creatediagram(Serializablediagram serializeddiagram)
        {
            GameObject diagramObj = new GameObject(serializeddiagram.diagramName + " root object");

            // create the diagram
            var diagram = diagramObj.AddComponent<Diagram>();
            diagram.diagramName = serializeddiagram.diagramName;
            diagram.Initialisediagram(serializeddiagram);

            return diagram;
        }
    }
}
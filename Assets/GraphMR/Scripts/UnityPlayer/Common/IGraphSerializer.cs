using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiagramMR
{
    public interface IdiagramSerializer
    {
        /// <summary>
        /// The list of files that this serializer can provide
        /// </summary>
        List<string> FileNames { get; }

        /// <summary>
        /// An identifier for this serializer, what sort of serialization does this serializer do?
        /// </summary>
        string Identifier { get; }

        /// <summary>
        /// Loads a diagram from a file 
        /// </summary>
        /// <param name="diagramName"></param>
        /// <returns></returns>
        Serializablediagram Loaddiagram(string diagramName);

        /// <summary>
        /// Saves a diagram to a file
        /// </summary>
        /// <param name="diagram"></param>
        void Savediagram(Serializablediagram diagram);

    }
}
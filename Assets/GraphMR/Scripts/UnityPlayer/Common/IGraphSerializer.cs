using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraphMR
{
    public interface IGraphSerializer
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
        /// Loads a graph from a file 
        /// </summary>
        /// <param name="graphName"></param>
        /// <returns></returns>
        SerializableGraph LoadGraph(string graphName);

        /// <summary>
        /// Saves a graph to a file
        /// </summary>
        /// <param name="graph"></param>
        void SaveGraph(SerializableGraph graph);

    }
}
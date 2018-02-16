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

        

    }
}
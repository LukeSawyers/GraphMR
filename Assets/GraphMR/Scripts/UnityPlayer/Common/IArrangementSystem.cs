using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace diagramMR
{
    public interface IArrangementSystem : IPresentable
    {
        /// <summary>
        /// Sets the list of nodes that will be arranged
        /// </summary>
        List<Node> Nodes { set; }

        /// <summary>
        /// Sets the list of connectors that will be arranged
        /// </summary>
        List<Connector> Connectors { set; }

        /// <summary>
        /// Enables this arrangement system
        /// </summary>
        void Enable();

        /// <summary>
        /// Disables this arrangement system
        /// </summary>
        void Disable();

    }
}
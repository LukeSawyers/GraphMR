using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace diagramMR
{
    /// <summary>
    /// An interface for an Item that can be presented
    /// </summary>
    public interface IPresentable
    {
        /// <summary>
        /// The name of this presenable
        /// </summary>
        string PresenatableName { get; }

        /// <summary>
        /// Help text to display for this presentable
        /// </summary>
        string HelpText { get; }

        /// <summary>
        /// The sprite to use as an icon for this presentatble 
        /// </summary>
        Sprite IconImage { get; }

    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraphMR
{
    public interface IWindowSystem
    {
        /// <summary>
        /// Enables this window system
        /// </summary>
        void Enable();

        /// <summary>
        /// Disables this window system
        /// </summary>
        void Disable();

    }
}

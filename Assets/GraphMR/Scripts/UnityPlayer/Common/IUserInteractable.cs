using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiagramMR
{
    public interface IUserInteractable
    {
        /// <summary>
        /// Method called when a user input raycast hits this gameobject
        /// </summary>
        void OnRaycastHit(InteractionInformation information);

    }
}

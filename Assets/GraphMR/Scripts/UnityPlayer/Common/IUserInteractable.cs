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

        /// <summary>
        /// Called when the focus of the interaction shifts onto this object
        /// </summary>
        void OnFocusEnter();

        /// <summary>
        /// Called when the focus of the interaction shifts away from this object
        /// </summary>
        void OnFocusExit();
    }
}

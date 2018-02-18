using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraphMR
{
    /// <summary>
    /// Interface for a component that manages the main camera
    /// </summary>
    public interface ICameraManager : IPresentable
    {
        /// <summary>
        /// The name of this type of camera manager
        /// </summary>
        string CameraManagerName { get; }

        /// <summary>
        /// The region of interest that this camera should focus on 
        /// </summary>
        Bounds Roi { get; set; }

        /// <summary>
        /// The camera that this manager should control
        /// </summary>
        Camera ControlledCamera { get; set; }

        /// <summary>
        /// Enables this camera manager
        /// </summary>
        void Enable();

        /// <summary>
        /// Disables this camera manager
        /// </summary>
        void Disable();
    }
}
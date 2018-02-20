using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiagramMR
{
    /// <summary>
    /// Represents user input when this raycast was made
    /// </summary>
    public class InteractionInformation
    {
        public enum ButtonState
        {
            None = 0,
            PrimaryClick = 1,
            AltClick = 2,
        }

        /// <summary>
        /// Bitmask of the input keys state when this object was created
        /// </summary>
        public ButtonState InputKeysState
        {
            get;
            private set;
        }

        /// <summary>
        /// Bitmask of the input keys down when this object was created
        /// </summary>
        public ButtonState InputKeysDown
        {
            get;
            private set;
        }

        /// <summary>
        /// Bitmask of the input keys up when this object was created
        /// </summary>
        public ButtonState InputKeysUp
        {
            get;
            private set;
        }

        /// <summary>
        /// The position of the camera when this object was created
        /// </summary>
        public Vector3 CameraPosition
        {
            get;
            private set;
        }

        /// <summary>
        /// The position of the raycast hit when this object was created
        /// </summary>
        public Vector3 HitPosition
        {
            get;
            private set;
        }

        /// <summary>
        /// Indicates if this information has already been consumed, can only be set once
        /// </summary>
        public bool Consumed
        {
            get
            {
                return _consumed;
            }
            set
            {
                if (value)
                {
                    _consumed = true;
                }
            }
        }

        private bool _consumed = false;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="inputKeysState"></param>
        /// <param name="inputKeysDown"></param>
        /// <param name="inputKeysUp"></param>
        /// <param name="cameraPosition"></param>
        /// <param name="hitPosition"></param>
        public InteractionInformation(ButtonState inputKeysState, ButtonState inputKeysDown, ButtonState inputKeysUp, Vector3 cameraPosition, Vector3 hitPosition)
        {
            InputKeysState = inputKeysState;
            InputKeysDown = inputKeysDown;
            InputKeysUp = inputKeysUp;
            CameraPosition = cameraPosition;
            HitPosition = hitPosition;
        }
    }
}
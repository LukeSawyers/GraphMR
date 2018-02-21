using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DiagramMR.UserInterface
{
    /// <summary>
    /// Represents a simple button
    /// </summary>
    public class SimpleButton : MonoBehaviour, IUserInteractable
    {
        #region IUserInteractable

        void IUserInteractable.OnFocusEnter()
        {
            _onFocusEnter.Invoke();
        }

        void IUserInteractable.OnFocusExit()
        {
            _onFocusExit.Invoke();
        }

        void IUserInteractable.OnRaycastHit(InteractionInformation information)
        {
            if (information.InputKeysDown == InteractionInformation.ButtonState.PrimaryClick)
            {
                _onClickDown.Invoke();
            }

            if (information.InputKeysDown == InteractionInformation.ButtonState.AltClick)
            {
                _onAltClickDown.Invoke();
            }

            if (information.InputKeysUp == InteractionInformation.ButtonState.PrimaryClick)
            {
                _onClickUp.Invoke();
            }

            if (information.InputKeysUp == InteractionInformation.ButtonState.AltClick)
            {
                _onAltClickUp.Invoke();
            }
        }

        #endregion

        /// <summary>
        /// Event raised when the UI focus enters this button
        /// </summary>
        public event UnityAction OnFocusEnter
        {
            add
            {
                _onFocusEnter.AddListener(value);
            }
            remove
            {
                _onFocusEnter.RemoveListener(value);
            }
        }

        /// <summary>
        /// Event raised when the UI focus exits this button
        /// </summary>
        public event UnityAction OnFocusExit
        {
            add
            {
                _onFocusExit.AddListener(value);
            }
            remove
            {
                _onFocusExit.RemoveListener(value);
            }
        }

        [Header("Focus")]
        [SerializeField]
        private UnityEvent _onFocusEnter = new UnityEvent();
        [SerializeField]
        private UnityEvent _onFocusExit = new UnityEvent();

        [Header("Click Events")]
        [SerializeField]
        private UnityEvent _onClickDown = new UnityEvent();
        [SerializeField]
        private UnityEvent _onClickUp = new UnityEvent();
        [SerializeField]
        private UnityEvent _onAltClickDown = new UnityEvent();
        [SerializeField]
        private UnityEvent _onAltClickUp = new UnityEvent();

    }
}

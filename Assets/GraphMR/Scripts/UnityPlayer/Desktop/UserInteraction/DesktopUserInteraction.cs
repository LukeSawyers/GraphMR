using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiagramMR.UserInteraction.Desktop
{
    [DisallowMultipleComponent]
    public class DesktopUserInteraction : MonoBehaviour, IUserInteractionSystem
    {
        /// <summary>
        /// The camera to use for user interaction
        /// </summary>
        Camera IUserInteractionSystem.InteractionCamera
        {
            get
            {
                return _interactionCamera;
            }
            set
            {
                _interactionCamera = value;
            }
        }

        [SerializeField]
        private Camera _interactionCamera;

        private bool _clickState = false;
        private bool _clickDown = false;
        private bool _clickUp = false;

        private bool _altClickState = false;
        private bool _altClickDown = false;
        private bool _altClickUp = false;

        private void Update()
        {
            // collect ui
            _clickState = Input.GetMouseButton(0);
            _clickDown = Input.GetMouseButtonDown(0);
            _clickUp = Input.GetMouseButtonUp(0);

            _altClickState = Input.GetMouseButton(1);
            _altClickDown = Input.GetMouseButtonDown(1);
            _altClickUp = Input.GetMouseButtonUp(1);

            // raycast
            Ray ray = ((IUserInteractionSystem)this).InteractionCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                var keyState = (_clickState ? InteractionInformation.ButtonState.PrimaryClick : InteractionInformation.ButtonState.None)
                    | (_altClickState ? InteractionInformation.ButtonState.AltClick : InteractionInformation.ButtonState.None);

                var keyStateDown = (_clickDown ? InteractionInformation.ButtonState.PrimaryClick : InteractionInformation.ButtonState.None)
                    | (_altClickDown ? InteractionInformation.ButtonState.AltClick : InteractionInformation.ButtonState.None);

                var keyStateUp = (_clickUp ? InteractionInformation.ButtonState.PrimaryClick : InteractionInformation.ButtonState.None)
                    | (_altClickUp ? InteractionInformation.ButtonState.AltClick : InteractionInformation.ButtonState.None);

                var info = new InteractionInformation(keyState, keyStateDown, keyStateUp, ((IUserInteractionSystem)this).InteractionCamera.transform.position, hit.point);
                var hitObj = hit.collider.gameObject;
                var interactables = hitObj.GetComponents<IUserInteractable>();
                foreach(var interactable in interactables)
                {
                    interactable.OnRaycastHit(info);
                    info.Consumed = true;
                }
            }
        }
    }
}


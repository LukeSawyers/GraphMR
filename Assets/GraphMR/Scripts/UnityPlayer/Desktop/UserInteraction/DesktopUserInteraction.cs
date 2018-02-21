using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiagramMR.UserInteraction.Desktop
{
    [DisallowMultipleComponent]
    public class DesktopUserInteraction : MonoBehaviour, IUserInteractionSystem, IUserInteractable
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

        /// <summary>
        /// If the raycast hits nothing, create a context menus
        /// </summary>
        /// <param name="information"></param>
        void IUserInteractable.OnRaycastHit(InteractionInformation information)
        {
            Debug.Log(string.Format("Raycast Hit on {0}. KeyState {1}", gameObject.name, information.InputKeysState));

            // if right click down bring up the menu
            if(information.InputKeysDown == InteractionInformation.ButtonState.AltClick)
            {
                _rightClickMenu.transform.position = information.HitPosition;
                _rightClickMenu.transform.LookAt(Camera.main.transform);
                _rightClickMenu.SetActive(true);
            }
        }

        [SerializeField]
        private Camera _interactionCamera;

        [SerializeField]
        private GameObject _rightClickMenu;

        private List<IUserInteractable> _focused = new List<IUserInteractable>();

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

            var keyState = (_clickState ? InteractionInformation.ButtonState.PrimaryClick : InteractionInformation.ButtonState.None)
                    | (_altClickState ? InteractionInformation.ButtonState.AltClick : InteractionInformation.ButtonState.None);

            var keyStateDown = (_clickDown ? InteractionInformation.ButtonState.PrimaryClick : InteractionInformation.ButtonState.None)
                | (_altClickDown ? InteractionInformation.ButtonState.AltClick : InteractionInformation.ButtonState.None);

            var keyStateUp = (_clickUp ? InteractionInformation.ButtonState.PrimaryClick : InteractionInformation.ButtonState.None)
                | (_altClickUp ? InteractionInformation.ButtonState.AltClick : InteractionInformation.ButtonState.None);

            // raycast
            Ray ray = ((IUserInteractionSystem)this).InteractionCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // if the raycast hits a collider, find all the interactables
            if (Physics.Raycast(ray, out hit, 100))
            {
                var info = new InteractionInformation(keyState, keyStateDown, keyStateUp, ((IUserInteractionSystem)this).InteractionCamera.transform.position, hit.point);
                var hitObj = hit.collider.gameObject;
                var interactables = hitObj.GetComponents<IUserInteractable>();
                foreach(var interactable in interactables)
                {
                    interactable.OnRaycastHit(info);
                    info.Consumed = true;

                    // run focus method on newly focused objects
                    if (!_focused.Contains(interactable))
                    {
                        interactable.OnFocusEnter();
                        _focused.Add(interactable);
                    }
                }

                // remove focused objects if they are not in the interactables
                var focusedCopy = new List<IUserInteractable>(_focused);
                focusedCopy.ForEach(f =>
                {
                    if (!interactables.Contains(f))
                    {
                        _focused.Remove(f);
                        f.OnFocusExit();
                    }
                });
            }
            // if nothing is hit, send the info to this
            else
            {
                var info = new InteractionInformation(keyState, keyStateDown, keyStateUp, ((IUserInteractionSystem)this).InteractionCamera.transform.position, ray.GetPoint(1f));
                ((IUserInteractable)this).OnRaycastHit(info);

                // remove all focus objects
                var focusedCopy = new List<IUserInteractable>(_focused);
                focusedCopy.ForEach(f =>
                {
                    _focused.Remove(f);
                    f.OnFocusExit();
                });
            }
        }

        public void OnFocusEnter()
        {
            
        }

        public void OnFocusExit()
        {
            
        }
    }
}


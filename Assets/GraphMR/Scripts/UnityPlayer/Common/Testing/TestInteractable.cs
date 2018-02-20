using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiagramMR
{
    public class TestInteractable : MonoBehaviour, IUserInteractable {

        void IUserInteractable.OnFocusEnter()
        {
            Debug.Log(string.Format("Focus on {0}. Entered", gameObject.name));
        }

        void IUserInteractable.OnFocusExit()
        {
            Debug.Log(string.Format("Focus on {0}. Exited", gameObject.name));
        }

        void IUserInteractable.OnRaycastHit(InteractionInformation information)
        {
            Debug.Log(string.Format("Raycast Hit on {0}. KeyState {1}", gameObject.name, information.InputKeysState));
        }
    }
}


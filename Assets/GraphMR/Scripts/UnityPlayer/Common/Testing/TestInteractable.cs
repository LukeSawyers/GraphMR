using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiagramMR
{
    public class TestInteractable : MonoBehaviour, IUserInteractable {

        public void OnRaycastHit(InteractionInformation information)
        {
            Debug.Log(string.Format("Raycast Hit on {0}. KeyState {1}", gameObject.name, information.InputKeysState));
        }
    }
}


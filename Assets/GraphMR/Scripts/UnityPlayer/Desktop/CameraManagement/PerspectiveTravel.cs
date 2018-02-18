using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraphMR.CameraManagement.Desktop
{
    [DisallowMultipleComponent]
    public class PerspectiveTravel : MonoBehaviour, ICameraManager
    {
        #region ICameraManager

        string ICameraManager.CameraManagerName
        {
            get
            {
                return "Perspective Travel";
            }
        }

        Bounds ICameraManager.Roi { get; set; }

        Camera ICameraManager.ControlledCamera
        {
            get
            {
                return _controlledCamera;
            }
            set
            {
                _controlledCamera = value;
            }
        }

        void ICameraManager.Disable()
        {
            this.enabled = false;
        }

        void ICameraManager.Enable()
        {
            this.enabled = true;
        }

        #endregion

        #region IPresentable

        string IPresentable.PresenatableName
        {
            get
            {
                return ((ICameraManager)this).CameraManagerName;
            }
        }

        string IPresentable.HelpText
        {
            get
            {
                return "Travel through the diagram with a perspective view";
            }
        }

        Sprite IPresentable.IconImage
        {
            get
            {
                return _iconImage;
            }
        }

        #endregion

        #region Fields

        private float _extendedPressMultiplier = 1f;
        private bool _rightClickDown = false;
        private Vector3 _mouseDownStartPosition = new Vector3();
        private Vector3 _mouseDelta = Vector3.zero;
        private Vector3 _mouseDownCameraEulerStart = new Vector3();

        #region Fields.Serialized

        [Tooltip("The icon to use to present this object")]
        [SerializeField]
        private Sprite _iconImage;
        [Tooltip("The rotation sensitivity")]
        [SerializeField]
        private Vector2 _rotationSensitivity = new Vector2(1, 1);
        [Tooltip("The movement sensitivity")]
        [SerializeField]
        private Vector3 _movementSensitivity = new Vector3(1, 1, 1);
        [Tooltip("Camera")]
        [SerializeField]
        private Camera _controlledCamera;
        [Tooltip("Value added for every frame that a key has been pressed to the translation magnitude")]
        [SerializeField]
        private float _extendedPressMultiplierAdder = 0.01f;

        #endregion
        
        #endregion

        private void Update()
        {
            // right click down
            if (Input.GetMouseButtonDown(1))
            {
                _rightClickDown = true;
                _mouseDownStartPosition = new Vector3(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);
                _mouseDownCameraEulerStart = ((ICameraManager)this).ControlledCamera.transform.rotation.eulerAngles;
                _mouseDelta = Vector3.zero;
            }

            // right click up
            if (Input.GetMouseButtonUp(1))
            {
                _rightClickDown = false;
            }

            if (_rightClickDown)
            {
                // get the current mouse position
                var mousePosition = new Vector3(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);

                // calculate the amount of movement since mousedown
                _mouseDelta = mousePosition - _mouseDownStartPosition;

                // calculate the rotation delta based on the sensitivity and the mouse delta
                var rotationDelta = new Vector3(_mouseDelta.y * _rotationSensitivity.y, _mouseDelta.x * _rotationSensitivity.x);

                // calculate the camera oritation based on the start position and delta
                var mouseDownCameraEuler = _mouseDownCameraEulerStart + rotationDelta;

                // 
                ((ICameraManager)this).ControlledCamera.transform.rotation = Quaternion.Euler(mouseDownCameraEuler);
            }

            var translation = Vector3.zero;
            var keyDown = false;

            // forward
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                translation += ((ICameraManager)this).ControlledCamera.transform.forward * _movementSensitivity.z;
                keyDown = true;
            }
            // backward
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                translation -= ((ICameraManager)this).ControlledCamera.transform.forward * _movementSensitivity.z;
                keyDown = true;
            }
            // left
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                translation -= ((ICameraManager)this).ControlledCamera.transform.right * _movementSensitivity.x;
                keyDown = true;
            }
            // right
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                translation += ((ICameraManager)this).ControlledCamera.transform.right * _movementSensitivity.x;
                keyDown = true;
            }
            // up
            if (Input.GetKey(KeyCode.E))
            {
                translation += ((ICameraManager)this).ControlledCamera.transform.up * _movementSensitivity.y;
                keyDown = true;
            }
            // down
            if (Input.GetKey(KeyCode.Q))
            {
                translation -= ((ICameraManager)this).ControlledCamera.transform.up * _movementSensitivity.y;
                keyDown = true;
            }

            if (keyDown)
            {
                _extendedPressMultiplier += _extendedPressMultiplierAdder;
            }
            else
            {
                _extendedPressMultiplier = 1f;
            }

            ((ICameraManager)this).ControlledCamera.transform.position += translation * _extendedPressMultiplier;
        }
    }
}
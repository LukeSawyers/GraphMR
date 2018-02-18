using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace diagramMR.CameraManagement.Desktop
{
    public class DesktopPanAndOrbit : MonoBehaviour, ICameraManager
    {
        #region ICameraManager 

        string ICameraManager.CameraManagerName
        {
            get
            {
                return "Pan and Orbit";
            }
        }

        Bounds ICameraManager.Roi
        {
            get;
            set;
        }
        Camera ICameraManager.ControlledCamera
        {
            get;
            set;
        }

        void ICameraManager.Disable()
        {
            enabled = false;
        }

        void ICameraManager.Enable()
        {
            enabled = true;
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
                return "Orbit around a moving focus point";
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

        [Tooltip("The icon to use to present this object")]
        [SerializeField]
        private Sprite _iconImage;
    }
}


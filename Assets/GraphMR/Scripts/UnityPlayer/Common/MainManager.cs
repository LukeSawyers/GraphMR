using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraphMR
{
    /// <summary>
    /// Top level governing manager for the GraphMR application
    /// </summary>
    [RequireComponent(typeof(ICameraManager))]
    [RequireComponent(typeof(IPresentationSystem))]
    [RequireComponent(typeof(GraphManager))]
    [DisallowMultipleComponent]
    public class MainManager : MonoBehaviour, IPresenter
    {
        #region IPresenter

        string IPresenter.WindowName
        {
            get
            {
                return "GraphMR";
            }
        }

        WindowOption IPresenter.WindowOptions
        {
            get
            {
                return WindowOption.None;
            }
        }

        Vector2 IPresenter.WindowSize
        {
            get
            {
                return new Vector2(100, 100);
            }
        }

        Vector2 IPresenter.WindowLocation
        {
            get
            {
                return new Vector2(100, 100);
            }
        }

        void IPresenter.Draw()
        {

        }

        #endregion

        private List<ICameraManager> _cameraManagers = new List<ICameraManager>();
        private List<IPresentationSystem> _windowSystems = new List<IPresentationSystem>();
        private GraphManager _graphManager;

        private ICameraManager _currentCameraManager;
        private IPresentationSystem _currentWindowSystem;

        protected virtual void Awake()
        {
            // get available components
            _cameraManagers = GetComponents<ICameraManager>().ToList();
            _windowSystems = GetComponents<IPresentationSystem>().ToList();

            // get child graph manager object
            _graphManager = GetComponent<GraphManager>();

            // enable the first graph manager, ensure all others are disabled
            if (_cameraManagers.Count > 0)
            {
                for (int i = 0; i < _cameraManagers.Count; i++)
                {
                    if (i == 0)
                    {
                        _cameraManagers[i].Enable();
                        _currentCameraManager = _cameraManagers[i];
                    }
                    _cameraManagers[i].Disable();
                }
            }
            else
            {
                Debug.LogWarning("MainManager does not have any camera managers, the user will be unable to control the camera");
            }

            // enable the first window manager, ensure all others are disabled
            if (_windowSystems.Count > 0)
            {
                for (int i = 0; i < _windowSystems.Count; i++)
                {
                    if (i == 0)
                    {
                        _windowSystems[i].Enable();
                        _currentWindowSystem = _windowSystems[i];
                    }
                    _windowSystems[i].Disable();
                }
            }
            else
            {
                Debug.LogWarning("MainManager does not have any window systems, any window presenters in the scene will not be presented");
            }

        }

        private void SetCameraManager(ICameraManager newCameraManager)
        {
            _currentCameraManager.Disable();
            _currentCameraManager = newCameraManager;
            _currentCameraManager.Enable();
        }

        private void SetWindowSystem(IPresentationSystem newWindowSystem)
        {
            _currentWindowSystem.Disable();
            _currentWindowSystem = newWindowSystem;
            _currentWindowSystem.Enable();
        }
    }
}


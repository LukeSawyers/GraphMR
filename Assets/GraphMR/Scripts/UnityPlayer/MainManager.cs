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
    [RequireComponent(typeof(IWindowSystem))]
    [RequireComponent(typeof(GraphManager))]
    [DisallowMultipleComponent]
    public class MainManager : MonoBehaviour, IWindowPresenter
    {
        string IWindowPresenter.WindowName
        {
            get
            {
                return "GraphMR";
            }
        }

        WindowOption IWindowPresenter.WindowOptions
        {
            get
            {
                return WindowOption.None;
            }
        }

        Vector2 IWindowPresenter.WindowSize
        {
            get
            {
                return new Vector2(100, 100);
            }
        }

        Vector2 IWindowPresenter.WindowLocation
        {
            get
            {
                return new Vector2(100, 100);
            }
        }

        private List<ICameraManager> _cameraManagers = new List<ICameraManager>();
        private List<IWindowSystem> _windowSystems = new List<IWindowSystem>();
        private GraphManager _graphManager;

        void IWindowPresenter.Draw()
        {

        }

        protected virtual void Awake()
        {
            // get available components
            _cameraManagers = GetComponents<ICameraManager>().ToList();
            _windowSystems = GetComponents<IWindowSystem>().ToList();

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
                    }
                    _windowSystems[i].Disable();
                }
            }
            else
            {
                Debug.LogWarning("MainManager does not have any window systems, any window presenters in the scene will not be presented");
            }

        }
    }
}


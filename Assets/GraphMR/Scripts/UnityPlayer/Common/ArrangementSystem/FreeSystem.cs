using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace diagramMR.Arrangment
{
    /// <summary>
    /// This system
    /// </summary>
    public class FreeSystem : MonoBehaviour, IArrangementSystem
    {
        #region IArrangementSystem

        List<Node> IArrangementSystem.Nodes
        {
            set
            {
                _nodes = value;
            }
        }

        List<Connector> IArrangementSystem.Connectors
        {
            set
            {
                _connectors = value;
            }
        }

        void IArrangementSystem.Disable()
        {
            enabled = false;
        }

        void IArrangementSystem.Enable()
        {
            enabled = true;
        }

        #endregion

        #region IPresentable

        string IPresentable.PresenatableName
        {
            get
            {
                return "Free";
            }
        }

        string IPresentable.HelpText
        {
            get
            {
                return "Connectors and Nodes move independently of eachother";
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

        [SerializeField]
        private Sprite _iconImage;

        private List<Node> _nodes = new List<Node>();
        private List<Connector> _connectors = new List<Connector>();
    }
}

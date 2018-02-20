using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiagramMR
{
    /// <summary>
    /// Represents a node in the diagram
    /// </summary>
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Renderer))]
    [DisallowMultipleComponent]
    public class Node : MonoBehaviour, IUserInteractable
    {

        #region IUserInteractable

        void IUserInteractable.OnRaycastHit(InteractionInformation information)
        {
            if (_focusedOn)
            {
                if(inform)

                if(information.InputKeysDown == InteractionInformation.ButtonState.PrimaryClick)
                {
                    _dragging = true;
                }

                if(information.InputKeysUp == InteractionInformation.ButtonState.PrimaryClick)
                {
                    _dragging = false;
                }
            }

            if (_dragging)
            {
                _latestClickInfo = information;
            }
        }

        void IUserInteractable.OnFocusEnter()
        {
            _focusedOn = true;
        }

        void IUserInteractable.OnFocusExit()
        {
            _focusedOn = false;
            _clickedOn = false;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The color of this node
        /// </summary>
        public Color NodeColor
        {
            get
            {
                return _nodeColor;
            }
            set
            {
                _nodeColor = value;
            }
        }

        /// <summary>
        /// The rigidbody attached to this object
        /// </summary>
        public Rigidbody Body
        {
            get
            {
                if(_body == null)
                {
                    _body = GetComponent<Rigidbody>();
                }
               
                return _body;
            }
        }

        /// <summary>
        /// The renderer for this node
        /// </summary>
        public Renderer NodeRenderer
        {
            get
            {
                if(_renderer == null)
                {
                    _renderer = GetComponent<Renderer>();
                }
                return _renderer;
            }
        }

        /// <summary>
        /// The unique id for this 
        /// </summary>
        public Guid UniqueID
        {
            get
            {
                return _uniqueID;
            }
            set
            {
                _uniqueID = value;
            }
        }

        /// <summary>
        /// This node's diagram
        /// </summary>
        public Diagram diagram
        {
            get
            {
                return _diagram;
            }
            set
            {
                _diagram = value;
            }
        }

        /// <summary>
        /// This node's type
        /// </summary>
        public string NodeType
        {
            get
            {
                return _nodeType;
            }
            set
            {
                _nodeType = value;
            }
        }

        #endregion

        #region Fields

        #region Fields.Serialized

        [SerializeField]
        private string _name = "Untitled";

        [SerializeField]
        private string _nodeType = "None";

        [SerializeField]
        private Color _nodeColor = Color.cyan;

        [SerializeField]
        private TextMesh _nameText;

        #endregion

        // base node variables
        private Diagram _diagram;

        private Rigidbody _body;

        private Guid _uniqueID;

        private Renderer _renderer;

        // ui variables
        private bool _focusedOn = false;
        private bool _clickedOn = false;
        private bool _dragging = false;
        private InteractionInformation _clickDownInfo;
        private InteractionInformation _latestClickInfo;

        #endregion

        #region Methods

        #region Methods.Public

        /// <summary>
        /// Creates a serializable version of this node
        /// </summary>
        /// <returns></returns>
        public SerializableNode ToSerializable()
        {
            return new SerializableNode(UniqueID, _name, _nodeType, _nodeColor);
        }

        #endregion

        #region Methods.Private

        private void Update()
        {
            SetColor();
            TextPositions();
            RunDragging();
        }

        private void SetColor()
        {
            NodeRenderer.material.color = _nodeColor;
        }

        private void TextPositions()
        {
            var awayFromCamera = (transform.position - Camera.main.transform.position).normalized;
            _nameText.transform.rotation = Quaternion.LookRotation(awayFromCamera, Vector3.up);
        }

        private void RunDragging()
        {
            if (_dragging)
            {

            }
        }

        #endregion

        #endregion
    }

    [Serializable]
    public struct SerializableNode
    {
        public SerializableNode(Guid uniqueID, string name, string type, Color color)
        {
            this.uniqueID = uniqueID;
            this.name = name;
            this.color = color;
            this.type = type;
        }

        public Guid uniqueID;
        public Color color;
        public string name;
        public string type;
    }
}
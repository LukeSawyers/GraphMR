using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraphMR
{
    /// <summary>
    /// Represents a node in the graph
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Renderer))]
    public class Node : MonoBehaviour
    {

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
        /// This node's graph
        /// </summary>
        public Graph Graph
        {
            get
            {
                return _graph;
            }
            set
            {
                _graph = value;
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

        [SerializeField]
        private string _name = "Untitled";

        [SerializeField]
        private string _nodeType = "None";

        [SerializeField]
        private Color _nodeColor = Color.cyan;

        [SerializeField]
        private TextMesh _nameText;

        private Graph _graph;

        private Rigidbody _body;

        private Guid _uniqueID;

        private Renderer _renderer;
       

        private void Update()
        {
            SetColor();
            TextPositions();
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

        /// <summary>
        /// Creates a serializable version of this node
        /// </summary>
        /// <returns></returns>
        public SerializableNode ToSerializable()
        {
            return new SerializableNode(UniqueID, _name, _nodeType, _nodeColor);
        }
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
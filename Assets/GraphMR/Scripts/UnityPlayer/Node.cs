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
                if(_uniqueID == null)
                {
                    _uniqueID = NodeFactory.GetUniqueID();
                }
                return (Guid)_uniqueID;
            }
            set
            {
                if (_uniqueID == null)
                {
                    _uniqueID = value;
                }
            }
        }

        private Rigidbody _body;

        private Guid? _uniqueID;

        [SerializeField]
        private string _name = "Untitled";
        
        [SerializeField]
        private List<string> _tags = new List<string>();

        [SerializeField]
        private Color _nodeColor = Color.cyan;

        [SerializeField]
        private TextMesh _nameText;

        private Renderer _renderer;
        
        private void Start()
        {
            ForceSystem.Nodes.Add(this);
            NodeFactory.Nodes.Add(UniqueID, this);
        }

        private void OnDestroy()
        {
            ForceSystem.Nodes.Remove(this);
            NodeFactory.Nodes.Remove(UniqueID);
        }

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
            return new SerializableNode(UniqueID, _name, _tags, _nodeColor);
        }
    }

    [System.Serializable]
    public struct SerializableNode
    {
        public SerializableNode(Guid uniqueID, string name, List<string> tags, Color color)
        {
            this.uniqueID = uniqueID;
            this.name = name;
            this.color = color;
            this.tags = tags;
        }

        public Guid uniqueID;
        public Color color;
        public string name;
        private List<string> tags;
    }
}
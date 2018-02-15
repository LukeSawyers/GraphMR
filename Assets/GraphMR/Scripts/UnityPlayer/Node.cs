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
        /// 
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

        private Rigidbody _body;

        [SerializeField]
        private Color _nodeColor = Color.cyan;

        private Renderer _renderer;
        
        private void Awake()
        {
            ForceSystem.Nodes.Add(this);
        }

        private void OnDestroy()
        {
            ForceSystem.Nodes.Remove(this);
        }

        private void Update()
        {
            SetColor();
        }

        private void SetColor()
        {
            NodeRenderer.material.color = _nodeColor;
        }
    }
}

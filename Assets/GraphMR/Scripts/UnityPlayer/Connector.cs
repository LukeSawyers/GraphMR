using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraphMR
{
    [RequireComponent(typeof(LineRenderer))]
    public class Connector : MonoBehaviour
    {
        /// <summary>
        /// The node at the start of this connector
        /// </summary>
        public Node OriginNode
        {
            get
            {
                return _originNode;
            }
            set
            {
                _originNode = value;
            }
        }

        /// <summary>
        /// The node at the end of this connector
        /// </summary>
        public Node EndNode
        {
            get
            {
                return _endNode;
            }
            set
            {
                _endNode = value;
            }
        }

        /// <summary>
        /// The LineRenderer this connector uses
        /// </summary>
        public LineRenderer LineRenderer
        {
            get
            {
                if(_lineRenderer == null)
                {
                    _lineRenderer = GetComponent<LineRenderer>();
                }
                return _lineRenderer;
            }
        }

        /// <summary>
        /// The enabled status of this connector
        /// </summary>
        public bool IsEnabled
        {
            get
            {
                if (_originNode == null || _endNode == null)
                {
                    return false;
                }
                return gameObject.activeInHierarchy && _originNode.enabled && _endNode.enabled;
            }
        }

        /// <summary>
        /// The distance between the two nodes of this connector
        /// </summary>
        public float Distance
        {
            get
            {
                return Vector3.Distance(_originNode.transform.position, _endNode.transform.position);
            }
        }

        private LineRenderer _lineRenderer;

        [SerializeField]
        private Node _originNode;
        [SerializeField]
        private Node _endNode;

        private void Update()
        {
            LineRenderer.SetPosition(0, _originNode.transform.position);
            LineRenderer.SetPosition(1, _endNode.transform.position);
            LineRenderer.startWidth = (0.01f);
            LineRenderer.endWidth = (0.02f);
        }

        public SerializableConnector ToSerializable()
        {
            return new SerializableConnector(_originNode.UniqueID, _endNode.UniqueID);
        }
    }

    /// <summary>
    /// A serializable version of a connector
    /// </summary>
    [Serializable]
    public struct SerializableConnector
    {
        public SerializableConnector(Guid originNodeID, Guid endNodeID)
        {
            this.originNodeID = originNodeID;
            this.endNodeID = endNodeID;
        }

        public Guid originNodeID;
        public Guid endNodeID;
    }
}
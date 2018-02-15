using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraphMR
{
    public class ForceSystem : MonoBehaviour
    {
        /// <summary>
        /// All nodes in the scene
        /// </summary>
        public static List<Node> Nodes
        {
            get
            {
                return _nodes;
            }
        }

        /// <summary>
        /// All nodes in the scene
        /// </summary>
        public static List<Connector> Connectors
        {
            get
            {
                return _connectors;
            }
        }

        private static List<Connector> _connectors = new List<Connector>();

        private static List<Node> _nodes = new List<Node>();

        [SerializeField]
        private float _repellingForce = 1;
        [SerializeField]
        private float _repellingForceRadius = 1;
        [SerializeField]
        private float _dragValue = 10;
        [SerializeField]
        private float _springConstant = 1;

        void Awake()
        {
            _nodes = new List<Node>();
        }

        void FixedUpdate()
        {
            ApplyRigidBodyValues();
            ApplyNodeForces();
            ApplyConnectorForces();
        }

        private void ApplyRigidBodyValues()
        {
            _nodes.ForEach((n) =>
            {
                n.Body.drag = _dragValue;
            });
        }

        /// <summary>
        /// Applies repelling forces between nodes
        /// </summary>
        private void ApplyNodeForces()
        {
            _nodes.ForEach((n) =>
            {
                if (!n.enabled)
                {
                    return;
                }

                _nodes.ForEach((n2) => 
                {
                    if (!n2.enabled)
                    {
                        return;
                    }

                    if (n != n2)
                    {
                        n.Body.AddExplosionForce(_repellingForce, n2.transform.position, _repellingForceRadius);
                    }
                });
            });
        }

        /// <summary>
        /// Applies attracting forces between nodes with a
        /// </summary>
        private void ApplyConnectorForces()
        {
            _connectors.ForEach((c) =>
            {
                if (!c.IsEnabled)
                {
                    return;
                }

                var dist = c.Distance;
                c.OriginNode.Body.AddForce(_springConstant * (c.EndNode.transform.position - c.OriginNode.transform.position), ForceMode.Force);
                c.EndNode.Body.AddForce(_springConstant * (c.OriginNode.transform.position - c.EndNode.transform.position), ForceMode.Force);
            });
        }
    }
}
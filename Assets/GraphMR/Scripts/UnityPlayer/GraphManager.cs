using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraphMR
{
    [RequireComponent(typeof(GraphFactory))]
    [RequireComponent(typeof(ForceSystem))]
    [RequireComponent(typeof(IGraphSerializer))]
    public class GraphManager : MonoBehaviour
    {

        private List<IGraphSerializer> _serializers = new List<IGraphSerializer>();


    }
}

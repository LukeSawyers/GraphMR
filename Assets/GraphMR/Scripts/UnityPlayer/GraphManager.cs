using System.Linq;
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

        private List<Graph> OpenGraphs = new List<Graph>();

        private GraphFactory _graphFactory;

        private void Awake()
        {
            _graphFactory = GetComponent<GraphFactory>();
            _serializers = GetComponents<IGraphSerializer>().ToList();
        }

        /// <summary>
        /// Returns the list of available save options
        /// </summary>
        /// <returns></returns>
        public List<string> GetSaveOptions()
        {
            return _serializers.Select(s => s.Identifier).ToList();
        }

        /// <summary>
        /// Creates a new empty graph
        /// </summary>
        public void CreateGraph()
        {
            OpenGraphs.Add(_graphFactory.CreateGraph());
        }
        
        /// <summary>
        /// Closes the graph and saves it
        /// </summary>
        /// <param name="graphName"></param>
        /// <param name="saveOption"></param>
        public void CloseAndSaveGraph(string graphName, string saveOption)
        {

        }

        /// <summary>
        /// Closes the graph and saves it
        /// </summary>
        /// <param name="graphName"></param>
        /// <param name="saveOption"></param>
        public void CloseAndSaveGraphAsNew(string graphName, string newName, string saveOption)
        {

        }

        /// <summary>
        /// Closes an existing graph
        /// </summary>
        /// <param name="graphName"></param>
        public void CloseGraph(string graphName)
        {

        }

        /// <summary>
        /// Loads a graph 
        /// </summary>
        /// <param name="graphName"></param>
        public void LoadGraph(string graphName)
        {

        }

        /// <summary>
        /// Saves a graph
        /// </summary>
        /// <param name="graphName"></param>
        /// <param name="saveOption"></param>
        public void SaveGraph(string graphName, string saveOption)
        {

        }

        /// <summary>
        /// Saves a graph as a new file
        /// </summary>
        /// <param name="graphName"></param>
        /// <param name="newName"></param>
        /// <param name="saveOption"></param>
        public void SaveGraphAsNew(string graphName, string newName, string saveOption)
        {

        }
    }
}

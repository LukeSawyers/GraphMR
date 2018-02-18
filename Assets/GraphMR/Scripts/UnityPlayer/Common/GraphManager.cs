using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraphMR
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(IArrangementSystem))]
    [RequireComponent(typeof(IGraphSerializer))]
    [RequireComponent(typeof(ConnectorFactory))]
    [RequireComponent(typeof(NodeFactory))]
    public class GraphManager : MonoBehaviour, IPresenter
    {
        #region IWindowPresenter

        string IPresenter.WindowName
        {
            get
            {
                return "Graph Manager";
            }
        }

        WindowOption IPresenter.WindowOptions
        {
            get
            {
                return WindowOption.None;
            }
        }

        Vector2 IPresenter.WindowSize
        {
            get
            {
                return new Vector2(100, 100);
            }
        }

        Vector2 IPresenter.WindowLocation
        {
            get
            {
                return new Vector2(100, 100);
            }
        }

        void IPresenter.Draw()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private List<IGraphSerializer> _serializers = new List<IGraphSerializer>();
        private List<IArrangementSystem> _arrangementSystems = new List<IArrangementSystem>();
        private List<Graph> OpenGraphs = new List<Graph>();

        protected virtual void Awake()
        {
            // get serializers
            _serializers = GetComponents<IGraphSerializer>().ToList();

            // get arrangement systems and enable the first one
            _arrangementSystems = GetComponents<IArrangementSystem>().ToList();
            if(_arrangementSystems.Count > 0)
            {
                for (int i = 0; i < _arrangementSystems.Count; i++)
                {
                    if(i == 0)
                    {
                        
                    }
                    _arrangementSystems[i].Disable();
                }
            }
            else
            {
                Debug.LogWarning("Graph Manager, no valid arrangement system available, nodes will not be able to be arranged");
            }
            
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
            OpenGraphs.Add(GraphFactory.CreateGraph());
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

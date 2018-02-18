using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace diagramMR
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(IArrangementSystem))]
    [RequireComponent(typeof(IdiagramSerializer))]
    [RequireComponent(typeof(ConnectorFactory))]
    [RequireComponent(typeof(NodeFactory))]
    public class DiagramManager : MonoBehaviour, IPresenter
    {
        #region IWindowPresenter

        string IPresenter.WindowName
        {
            get
            {
                return "diagram Manager";
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

        private List<IdiagramSerializer> _serializers = new List<IdiagramSerializer>();
        private List<IArrangementSystem> _arrangementSystems = new List<IArrangementSystem>();
        private List<Diagram> Opendiagrams = new List<Diagram>();

        protected virtual void Awake()
        {
            // get serializers
            _serializers = GetComponents<IdiagramSerializer>().ToList();

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
                Debug.LogWarning("diagram Manager, no valid arrangement system available, nodes will not be able to be arranged");
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
        /// Creates a new empty diagram
        /// </summary>
        public void Creatediagram()
        {
            Opendiagrams.Add(DiagramFactory.Creatediagram());
        }

        /// <summary>
        /// Closes an existing diagram
        /// </summary>
        /// <param name="diagramName"></param>
        public void Closediagram(string diagramName)
        {

        }

        /// <summary>
        /// Loads a diagram 
        /// </summary>
        /// <param name="diagramName"></param>
        public void Loaddiagram(string diagramName)
        {

        }

        /// <summary>
        /// Saves a diagram
        /// </summary>
        /// <param name="diagramName"></param>
        /// <param name="saveOption"></param>
        public void Savediagram(string diagramName, string saveOption)
        {

        }

        /// <summary>
        /// Saves a diagram as a new file
        /// </summary>
        /// <param name="diagramName"></param>
        /// <param name="newName"></param>
        /// <param name="saveOption"></param>
        public void SavediagramAsNew(string diagramName, string newName, string saveOption)
        {

        }

        
    }
}

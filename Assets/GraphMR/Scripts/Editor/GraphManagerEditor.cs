using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GraphMR.EditorExtensions
{
    [CustomEditor(typeof(GraphManager))]
    public class GraphManagerEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var graphManager = (GraphManager)target;

            if(GUILayout.Button("Create Graph"))
            {
                graphManager.CreateGraph();
            }
        }
    }
}

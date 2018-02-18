using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace diagramMR.EditorExtensions
{
    [CustomEditor(typeof(DiagramManager))]
    public class diagramManagerEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var diagramManager = (DiagramManager)target;

            if(GUILayout.Button("Create diagram"))
            {
                diagramManager.Creatediagram();
            }
        }
    }
}

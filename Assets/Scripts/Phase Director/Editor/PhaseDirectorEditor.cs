// Custom Editor using SerializedProperties.
// Automatic handling of multi-object editing, undo, and Prefab overrides.
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace OSGames.BoardGame {

    #if UNITY_EDITOR
    [CustomEditor(typeof(PhaseDirector))]
    [CanEditMultipleObjects]
    public class PhaseDirectorEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            serializedObject.Update();
            PhaseDirector director = (PhaseDirector) target;

            if (GUILayout.Button("Next Phase")){
                director.ExecuteNextPhase();
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
    #endif
}
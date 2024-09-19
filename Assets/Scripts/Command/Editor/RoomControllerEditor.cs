// Custom Editor using SerializedProperties.
// Automatic handling of multi-object editing, undo, and Prefab overrides.
using System.Collections.Generic;
using Org.BouncyCastle.Math.EC.Multiplier;
using UnityEditor;
using UnityEngine;

namespace OSGames.BoardGame{

    #if UNITY_EDITOR
    [CustomEditor(typeof(RoomController))]
    [CanEditMultipleObjects]
    public class RoomControllerEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            serializedObject.Update();
            RoomController rc = (RoomController) target;

            if (GUILayout.Button("Publish Sample Commands")){
                rc.TestPublish();
            }

            serializedObject.ApplyModifiedProperties ();
        }
    }
    #endif
}
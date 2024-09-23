// Custom Editor using SerializedProperties.
// Automatic handling of multi-object editing, undo, and Prefab overrides.
using System.Collections.Generic;
using Org.BouncyCastle.Math.EC.Multiplier;
using UnityEditor;
using UnityEngine;
using OSGames.BoardGame.Generic;

namespace OSGames.BoardGame{

    #if UNITY_EDITOR
    [CustomEditor(typeof(RoomActionListPublisher))]
    [CanEditMultipleObjects]
    public class RoomActionListPublisherEditor : Editor
    {
        // SerializedProperty damageProp;
        // SerializedProperty armorProp;
        // SerializedProperty cmdListProp;

        // SerializedProperty List<Command>;

        [SerializeField] bool testBool;
        [SerializeField] List<Command> cmdList;

        SerializedProperty cmdListProp;

        void OnEnable()
        {
            // Setup the SerializedProperties.
            // damageProp = serializedObject.FindProperty ("damage");
            // armorProp = serializedObject.FindProperty ("armor");
            // cmdListProp = serializedObject.FindProperty ("cmdList");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            // // Update the serializedProperty - always do this in the beginning of OnInspectorGUI.
            serializedObject.Update();

            RoomActionListPublisher publisher = (RoomActionListPublisher) target;

            // // Show the custom GUI controls.
            // // EditorGUILayout.IntSlider (damageProp, 0, 100, new GUIContent ("Damage"));

            // // // Only show the damage progress bar if all the objects have the same damage value:
            // // if (!damageProp.hasMultipleDifferentValues)
            // //     ProgressBar (damageProp.intValue / 100.0f, "Damage");

            // // EditorGUILayout.IntSlider (armorProp, 0, 100, new GUIContent ("Armor"));

            // // // Only show the armor progress bar if all the objects have the same armor value:
            // // if (!armorProp.hasMultipleDifferentValues)
            // //     ProgressBar (armorProp.intValue / 100.0f, "Armor");

            // // EditorGUILayout.PropertyField (gunProp, new GUIContent ("Gun Object"));
            // // cmdListProp.objectReferenceValue = new List<Command>();
            // // EditorGUILayout.PropertyField (cmdListProp, new GUIContent ("Command List"));
            // // EditorGUILayout.ObjectField (cmdListProp, new GUIContent ("Command List"));

            // // EditorGUI.ObjectField();
            // // EditorGUILayout.ObjectField();

            // // GUILayout

            // if (GUILayout.Button("Publish Sample Commands")){
            //     // Command cmd = CreateInstance<Command>();
            //     // proc.e_CommandAdded.Invoke(cmd);
            //     // proc.ExecuteCommand(cmd);
                
            //     // publisher.Publish(cmdListProp);
            //     publisher.TestPublish();
            // }


            // Apply changes to the serializedProperty - always do this in the end of OnInspectorGUI.
            serializedObject.ApplyModifiedProperties ();
        }
    }
    #endif
}
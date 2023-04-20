using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ArmatureTool.Tools {
    public class ArmatureTool_Editor : EditorWindow 
    {
       #region Varaiables
       GameObject selectedObject;
       string prefix;
       #endregion

       #region Builtin Methods
       public static void LaunchEditor()
       {
            var editorWin = GetWindow<ArmatureTool_Editor>("Rename Armature");
            editorWin.Show();
       }
       #endregion

       private void OnGUI()
       {

        EditorGUILayout.BeginVertical();
        EditorGUILayout.Space();

        selectedObject = (GameObject)EditorGUILayout.ObjectField("Rename Armature", selectedObject, typeof(GameObject), true);

        EditorGUILayout.Space();

        prefix = EditorGUILayout.TextField("Prefix: ", prefix);

        EditorGUILayout.Space();

        if(GUILayout.Button("Rename Armature", GUILayout.ExpandWidth(true), GUILayout.Height(40)))
        {
            RenameArmature();
        }

        EditorGUILayout.Space();
        EditorGUILayout.EndVertical();

        Repaint();
       }

       #region Custom Methods

        void RenameArmature()
        {
            if(!selectedObject)
            {
                EditorUtility.DisplayDialog("Rename Armature Warning", "At least one object need to be selected", "OK");
                return;
            }

            if(string.IsNullOrEmpty(prefix))
            {
                EditorUtility.DisplayDialog("Rename Armature Warning", "Prefix is empty", "OK");
            }

            if(selectedObject.transform.GetChild(0).gameObject.name != "Hips")
            {
                EditorUtility.DisplayDialog("Rename Armature Warning", "Hips must be the first child", "OK");
                return;
            }


            // Loop all children by BFS
            LinkedList<Transform> queue = new LinkedList<Transform>();
            queue.AddLast(selectedObject.transform.GetChild(0));

            while(queue.Count != 0)
            {
                Transform tmp = queue.First.Value;

                tmp.gameObject.name = prefix + tmp.gameObject.name;

                queue.RemoveFirst();

                foreach(Transform child in tmp.transform)
                {
                    queue.AddLast(child);
                }               
            }

        }

       #endregion
    }

}

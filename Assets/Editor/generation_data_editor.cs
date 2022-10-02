using UnityEngine;
using UnityEditor;
[CanEditMultipleObjects]
[CustomEditor(typeof(generation_data))]
public class generation_data_editor : Editor {
    public generation_data T;
    public void OnEnable() {
        T=(generation_data)target;
    }
    public override void OnInspectorGUI() {
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("chance:");
        T.chance = EditorGUILayout.IntField(T.chance);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Separator();
        EditorGUILayout.PrefixLabel("entrences");
        EditorGUILayout.BeginHorizontal();
        for (int i = 0; i < T.entrences.Length; i++)
        {
            T.entrences[i] = EditorGUILayout.Toggle(T.entrences[i]);
        }
        EditorGUILayout.EndHorizontal();
        if(EditorGUI.EndChangeCheck()){
            EditorUtility.SetDirty(T);
        }
    }
}

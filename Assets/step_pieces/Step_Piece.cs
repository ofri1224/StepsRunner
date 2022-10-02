using UnityEngine;
using UnityEditor;
[CreateAssetMenu(fileName = "new step_piece",menuName = "step piece",order = -100)]
public class Step_Piece : ScriptableObject
{
    public int chance;
    public GameObject step_piece_prefab;
    public bool[] entrences = new bool[3]; 
}
[CustomEditor(typeof(Step_Piece))]
public class Step_Piece_Editor : Editor{
    Step_Piece step_piece;
    Rect rt;
    int Texture_s;
    public void OnEnable() {
        step_piece = (Step_Piece)target;
        Texture_s = 20;
    }
    public override void OnInspectorGUI()
    {
        Event e = Event.current; // get current event
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("chance:");
        step_piece.chance = EditorGUILayout.IntField(step_piece.chance);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Separator();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("Step_prefab");
        step_piece.step_piece_prefab = EditorGUILayout.ObjectField(step_piece.step_piece_prefab,typeof(GameObject),false) as GameObject;
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Separator();
        if (step_piece != null && PrefabUtility.GetPrefabAssetType(step_piece) == PrefabAssetType.Regular)// check if object is null
        {
            if (EditorWindow.mouseOverWindow&&e.isScrollWheel)
            {
                Texture_s += Mathf.RoundToInt(e.delta.y);//contol thumbnail size with scrolling
            }
            EditorGUILayout.LabelField("", GUILayout.Width(Texture_s),GUILayout.Height(Texture_s)); // buffer so text won't overlap
            rt = GUILayoutUtility.GetLastRect();
            EditorGUI.DrawPreviewTexture(new Rect(rt.x, rt.y, Texture_s, Texture_s), AssetPreview.GetAssetPreview(step_piece.step_piece_prefab));
        }
        EditorGUILayout.PrefixLabel("entrences");
        EditorGUILayout.BeginHorizontal();
        for (int i = 0; i < step_piece.entrences.Length; i++)
        {
            step_piece.entrences[i] = EditorGUILayout.Toggle(step_piece.entrences[i]);
        }
        EditorGUILayout.EndHorizontal();
        if(EditorGUI.EndChangeCheck()){
            EditorUtility.SetDirty(step_piece);
        }
    }
}

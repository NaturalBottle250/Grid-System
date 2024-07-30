using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CustomGrid))]
public class GridEditor : Editor
{
    public override void OnInspectorGUI()
    {
        CustomGrid customGrid = (CustomGrid)target;

        GUIStyle headerStyle = new GUIStyle(GUI.skin.label)
        {
            fontStyle = FontStyle.Bold,
            fontSize = 14,
            contentOffset = new Vector2(0.5f,0f)
        };

        GUIStyle buttonStyle = new GUIStyle(GUI.skin.button)
        {
            fontStyle = FontStyle.Bold,
            fontSize = 12,
            fixedHeight = 30
        };

        EditorGUILayout.LabelField("Custom Grid Settings", headerStyle);

        //line separator
        EditorGUILayout.Space(5);
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

        //fields with custom styles
        customGrid.Width = EditorGUILayout.IntField("Width", customGrid.Width);
        customGrid.Height = EditorGUILayout.IntField("Height", customGrid.Height);
        customGrid.CellDimensions = EditorGUILayout.Vector3Field("Default Cell Size (Units)", customGrid.CellDimensions);
        
        
        

        EditorGUILayout.Space(10);
        //label, target, type, allowSceneObjects
        customGrid.DefaultCell =
            (GameObject)EditorGUILayout.ObjectField("Default Cell", customGrid.DefaultCell, typeof(GameObject), true);
        
        EditorGUILayout.Space(10);

        // dropdown for cell type
        customGrid.Type = (CustomGrid.CellType)EditorGUILayout.EnumPopup("Cell Type", customGrid.Type);

        EditorGUILayout.Space(10);

        //Button
        if (GUILayout.Button("Generate Grid", buttonStyle))
        {
            customGrid.GenerateGrid();
        }
    }
}
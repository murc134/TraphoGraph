using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GraphCanvas))]
[CanEditMultipleObjects]
public class GraphCanvasEditor : Editor
{
    GraphCanvas canvas;

    void OnEnable()
    {
        canvas = (GraphCanvas) target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

    }
}
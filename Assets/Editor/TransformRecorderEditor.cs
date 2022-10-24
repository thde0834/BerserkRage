using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TransformRecorder))]
public class TransformRecorderEditor : Editor
{
    private TransformRecorder component;

    private void Awake()
    {
        component = target as TransformRecorder;
    }

    [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
    static void DrawGizmoForMyScript(TransformRecorder scr, GizmoType gizmoType)
    {
        if (scr != null && scr.Position != null)
        {
            scr.Position.SetValue(scr.transform.position);

            if (scr.Rotation != null)
                scr.Rotation.SetValue(scr.transform.eulerAngles);

            Handles.color = scr.GizmosColor;
            Handles.DrawSolidDisc(
                scr.Position.Value,
                scr.transform.forward,
                0.05f
            );
        }
    }

}

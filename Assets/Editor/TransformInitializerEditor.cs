using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TransformInitializer))]
public class TransformInitializerEditor : Editor
{
    private TransformInitializer component;

    private void Awake()
    {
        component = target as TransformInitializer;
    }

    private void OnValidate()
    {
        if (component == null) return;

        if (component.Position != null)
            component.transform.position = component.Position.Value;

        if (component.Rotation != null)
            component.transform.eulerAngles = component.Rotation.Value;
    }

    [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
    static void DrawGizmoForMyScript(TransformInitializer scr, GizmoType gizmoType)
    {
        if (scr != null && scr.Position != null)
        {
            Handles.color = Color.red;
            Handles.DrawSolidDisc(
                scr.Position.Value,
                scr.transform.forward,
                0.05f
            );
        }

        if (scr.transform.hasChanged && scr.Position != null)
        {
            scr.SetPosition(scr.transform.position);
            scr.transform.hasChanged = false;
        }
    }

}

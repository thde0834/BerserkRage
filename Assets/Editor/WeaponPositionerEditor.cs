using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WeaponPositioner))]
public class WeaponPositionerEditor : Editor
{
    private WeaponPositioner component;

    private void Awake()
    {
        component = target as WeaponPositioner;
    }

    private void OnValidate()
    {
        if (component == null) return;

        if (component.Pivot != null)
            component.transform.position = component.Pivot.Value;
    }

    [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
    static void DrawGizmoForMyScript(WeaponPositioner scr, GizmoType gizmoType)
    {
        if (scr != null && scr.Pivot != null && scr.Radius != null)
        {
            Handles.color = Color.red;
            Handles.DrawWireDisc(scr.Pivot.Value,
                    scr.transform.forward,
                    scr.Radius.Value);
        }

        if (scr.transform.hasChanged && scr.Pivot != null)
        {
            scr.SetPivot(scr.transform.position + Vector3.left * scr.Radius.Value);
            scr.transform.hasChanged = false;
        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WeaponGizmosRenderer))]
public class WeaponGizmosRendererEditor : Editor
{
    private WeaponGizmosRenderer component;

    private void Awake()
    {
        component = target as WeaponGizmosRenderer;
    }

    [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
    static void DrawGizmoForMyScript(WeaponGizmosRenderer scr, GizmoType gizmoType)
    {
        if (scr != null && scr.Weapon != null)
        {
            var pivotPos = scr.Weapon.Pivot != null ? scr.Weapon.Pivot.Value : scr.transform.position + Vector3.left * scr.Weapon.Radius.Value;
            var maxRadius = scr.Weapon.Radius != null ? scr.Weapon.Radius.Value : 0f;

            scr.transform.position = pivotPos + Vector3.right * maxRadius;

            Handles.color = scr.GizmosColor;

            // Draw inner circle
            Handles.DrawSolidDisc(
                    pivotPos,
                    scr.transform.forward,
                    0.05f);

            // Draw Max radius
            Handles.DrawWireDisc(pivotPos,
                    scr.transform.forward,
                    maxRadius);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WeaponGripHandler))]
public class WeaponGripPositionerEditor : Editor
{
    private const float radius = 0.05f;
    private static Color drawColor = Color.red;

    [DrawGizmo(GizmoType.Selected)]
    static void DrawGizmoForMyScript(WeaponGripHandler scr, GizmoType gizmoType)
    {
        Handles.color = drawColor;

        Handles.DrawSolidDisc(
                    scr.transform.position,
                    scr.transform.forward,
                    radius);

        Handles.DrawLine(
            scr.transform.position,
            new Vector3(
                scr.transform.position.x + (2 * radius * Mathf.Cos((scr.transform.eulerAngles.z - 90f) * Mathf.Deg2Rad)),
                scr.transform.position.y + (2 * radius * Mathf.Sin((scr.transform.eulerAngles.z - 90f) * Mathf.Deg2Rad)),
                scr.transform.position.z),
            radius * 100f);
    }
}

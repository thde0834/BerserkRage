using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponHolderPositioner : MonoBehaviour
{
    [SerializeField]
    private Vector3Variable gripPosition, gripRotation;

    [SerializeField]
    private Vector3Variable handPosition, handRotation;

    private Vector3 pos, rot = Vector3.zero;

    private float radius, angle;

    private Dictionary<Vector3Variable, bool> hasChanged;

    private void Start()
    {
        radius = Mathf.Sqrt(Mathf.Pow(transform.localPosition.x, 2) + Mathf.Pow(transform.localPosition.y, 2));
        angle = Mathf.Atan2(transform.localPosition.y, transform.localPosition.x);

        hasChanged = new Dictionary<Vector3Variable, bool>()
        {
            { gripPosition, false },
            { gripRotation, false }
        };
    }

    private void OnEnable()
    {
        gripPosition.OnValueChanged += PositionHandler;
        gripRotation.OnValueChanged += RotationHandler;
    }
    private void OnDisable()
    {
        gripPosition.OnValueChanged -= PositionHandler;
        gripRotation.OnValueChanged -= RotationHandler;
    }

    private void PositionHandler(Vector3 gripPos)
    {
        if (hasChanged[gripPosition]) return;

        pos = gripPos;
        hasChanged[gripPosition] = true;

        // Check if all values in dict are true
        if (hasChanged.ContainsValue(false) == false)
        {
            SetHandPosition();
        }
    }
    private void RotationHandler(Vector3 gripRot)
    {
        if (hasChanged[gripRotation]) return;

        rot = gripRot;
        hasChanged[gripRotation] = true;

        // Check if all values in dict are true
        if (hasChanged.ContainsValue(false) == false)
        {
            SetHandPosition();
        }
    }

    private void SetHandPosition()
    {
        pos.Set(
            pos.x - radius * Mathf.Cos(rot.z * Mathf.Deg2Rad + angle),
            pos.y - radius * Mathf.Sin(rot.z * Mathf.Deg2Rad + angle),
            pos.z);

        handPosition.SetValue(pos);
        handRotation.SetValue(rot);

        hasChanged.Keys.ToList().ForEach(key => hasChanged[key] = false);
    }
}

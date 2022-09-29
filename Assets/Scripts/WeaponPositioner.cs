using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPositioner : MonoBehaviour
{
    [field: SerializeField] public Vector3Variable Pivot { get; private set; }
    [field: SerializeField] public FloatVariable Radius { get; private set; }

    public void SetPivot(Vector3 pivot) => Pivot.SetValue(pivot);

}

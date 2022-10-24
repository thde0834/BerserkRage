using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Weapon : ScriptableObject
{
    public GameObject Prefab;

    public Vector3Reference Pivot;

    public FloatReference Radius;
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGizmosRenderer : MonoBehaviour
{
    [field: SerializeField] public Weapon Weapon { get; private set; }
    [field: SerializeField] public Color GizmosColor { get; private set; } = Color.red;

}

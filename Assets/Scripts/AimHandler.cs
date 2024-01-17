using System;
using System.Collections;
using UnityEngine;

public class AimHandler : MonoBehaviour
{
    public static AimHandler Instance { get; private set; }
    
    private void Awake() => Instance = this;

    private void OnEnable()
    {
        GameplayController.OnAimChanged += OnAimChanged;
    }

    private void OnDisable()
    {
        GameplayController.OnAimChanged -= OnAimChanged;
    }

    private void OnAimChanged(Vector2 aim)
    {
        if (aim == Vector2.zero) return;
        aim.Normalize();
        WeaponManager.Instance.Transform(aim);
    }
}

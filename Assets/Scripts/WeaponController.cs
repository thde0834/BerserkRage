using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Vector2Variable AimVector;

    private void OnEnable() => AimVector.OnValueChanged += AimHandler;
    private void OnDisable() => AimVector.OnValueChanged -= AimHandler;

    private void AimHandler(Vector2 aimVector)
    {
        
    }
}

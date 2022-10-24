using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGripPositioner : MonoBehaviour, IEventListener
{
    [SerializeField]
    private BaseEventTrigger OnWeaponPositionChanged;

    [SerializeField]
    private Vector3Variable gripPosition, gripRotation;

    private void OnEnable()
    {
        OnWeaponPositionChanged.RegisterListener(this);
    }

    private void OnDisable()
    {
        OnWeaponPositionChanged.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        gripPosition.SetValue(transform.position);
        gripRotation.SetValue(transform.eulerAngles);
    }

}

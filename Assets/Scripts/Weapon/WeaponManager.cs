using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField]
    private Weapon currentWeapon;

    public static event Action<Weapon> OnWeaponChanged;
    
    // temporary
    private void Start()
    {
        SetWeapon(currentWeapon);
    }

    public void SetWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
        OnWeaponChanged?.Invoke(currentWeapon);
    }
}

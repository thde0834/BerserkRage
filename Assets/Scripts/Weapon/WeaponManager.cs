using System;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance { get; private set; }
    private void Awake() => Instance = this;

    // temp
    [SerializeField]
    private Weapon currentWeapon;
    private GameObject weaponPrefab;
    private WeaponHandler[] weaponControllers;

    [SerializeField]
    private Transform parent;

    // temporary
    private void OnEnable()
    {
        SetWeapon(currentWeapon);
    }

    public void SetWeapon(Weapon weapon)
    {
        if (weaponPrefab != null)
        {
            Destroy(weaponPrefab);
        }

        currentWeapon = weapon;
        weaponPrefab = Instantiate(currentWeapon.Prefab, parent);
        weaponControllers = weaponPrefab.GetComponentsInChildren<WeaponHandler>();
    }

    public void Transform(Vector2 aim)
    {
        foreach(var controller in weaponControllers)
        {
            controller.Transform(new object[] { aim });
        }
    }

}

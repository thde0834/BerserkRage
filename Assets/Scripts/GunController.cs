using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Gun gunObject;
    public GameObject bullet;

    public string gunName;  // replace later

    public event Action evolveEvent;
    public event Action<Gun> onStartEvent;

    public event Action fireEvent;

    public event Func<string, Gun> onGunLoadEvent;
    
    private void Start()
    {
        onStart();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Shoot();
        }
    }

    // Loads gun, sets data
    private void onStart()
    {
        gunObject = onGunLoadEvent?.Invoke(gunName);
        onStartEvent?.Invoke(gunObject);   
    }

    // Called to shoot gun
    private void Shoot()
    {
        fireEvent?.Invoke();
    }

    // Called to evolve gun
    private void Evolve()
    {   
        evolveEvent?.Invoke();
    }

}
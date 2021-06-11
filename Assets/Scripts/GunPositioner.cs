using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class GunPositioner : MonoBehaviour
{
    private GunLoader gunLoader;
    
    [SerializeField]
    private Gun GunObject;

    [SerializeField]
    private Transform GunPosition;

    [SerializeField]
    private Transform FirePointOBJ;

    private void Awake()
    {
        gunLoader = GetComponent<GunLoader>();
        GetComponent<GunController>().onStartEvent += onStart;
    }

    private void onStart(Gun gunObject)
    {
        GunObject = gunObject;
        PositionChanger(0);
    }

    private void PositionChanger(int index)
    {
        GunPosition.position = GunObject.position[index];
        FirePointOBJ.position = GunObject.firePoint[index];
    }
}

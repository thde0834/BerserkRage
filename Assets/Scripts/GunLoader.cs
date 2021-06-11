using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

/// <summary>
/// FINDS Gun Asset File, LOADS Gun
/// </summary>

public class GunLoader : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<GunController>().onGunLoadEvent += LoadGun;
    }
    
    private Gun LoadGun(string gunName)
    {
        Gun gunObject;

        // Collect GUN data values
        string filePath = "Guns\\" + gunName;
        if (File.Exists("Assets\\Resources\\" + filePath + ".asset"))
        {
            gunObject = Resources.Load<Gun>(filePath);
            Debug.Log("[GunLoader]: >> GUN.ASSET << FILE (" + filePath + ") loaded.");
        }
        else
        {
            Debug.Log("[GunLoader]: <ERROR> NO >> GUN.ASSET << FILE FOUND");
            gunObject = null;
        }

        return gunObject;
    }

}



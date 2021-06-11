using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class BulletLauncher : MonoBehaviour
{ 
    [SerializeField]
    private GunPositioner GP;
    [SerializeField]
    private Joystick JS;

    [SerializeField]
    private GameObject Camera;

    [SerializeField]
    private Transform Pivot;

    [SerializeField]
    private Transform FirePoint;

    [SerializeField]
    private Quaternion Angle;

    [SerializeField]
    private Gun GunObject;      // need for shooting stat values

    [SerializeField]
    private GameObject bullet;

    private string filePath;
    public string gunName;

    private void Awake()
    {
        GP = GetComponent<GunPositioner>();
        JS = Camera.GetComponent<Joystick>();
        GetComponent<GunController>().fireEvent += ShootBullet;
    }
    
    private void ShootBullet()
    {
        var spawnedProjectile = Instantiate(bullet, FirePoint.position, FirePoint.rotation);
    }

}

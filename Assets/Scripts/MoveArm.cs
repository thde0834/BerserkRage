using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class MoveArm : MonoBehaviour
{
    public Gun gun;
    public Transform gunPivot;
    public string gunName;
    private string filePath;

    public Transform upper, lower, wrist;

    [SerializeField]
    private float a, b, c;
    [SerializeField]
    private float bAng, cAng;
    [SerializeField]
    private float aimAng;

    // Fix Aim Angle depending on Gun's x and y coordinates.
    [SerializeField]
    private float fixAng;

    // Start is called before the first frame update
    void Start()
    {
        filePath = "Guns\\" + gunName;
        if (File.Exists("Assets\\Resources\\" + filePath + ".asset"))
        {
            Debug.Log("[MoveArm]: " + filePath + " loaded.");
            gun = Resources.Load<Gun>(filePath);
        }
        else
        {
            Debug.Log("[MoveArm]: <ERROR> NO FILE FOUND");
        }

        a = 0.5f;
        b = 0.5f;
        c = gun.radius[0];

        cAng = (a * a + b * b - c * c) / (2 * a * b);
        cAng = Mathf.Acos(cAng) * Mathf.Rad2Deg;
        cAng *= -1;

        bAng = (a * a + c * c - b * b) / (2 * a * c);
        bAng = Mathf.Acos(bAng) * Mathf.Rad2Deg;
        bAng *= -1;

    }

    // Update is called once per frame
    void Update()
    {
        fixAng = Mathf.Atan2(gun.position[0].y, gun.position[0].x) * Mathf.Rad2Deg;

        aimAng = gunPivot.eulerAngles.z;

        if (aimAng > 180)
        {
            aimAng -= 360;
        }

        upper.eulerAngles = new Vector3(0, 0, fixAng + aimAng + bAng + 90) ;
        lower.eulerAngles = new Vector3(0, 0, fixAng + aimAng + bAng + cAng - 90);
        // removed cuz look weird when y > 0
        //wrist.eulerAngles = new Vector3(0, 0, aimAng + 90); 
    }
}

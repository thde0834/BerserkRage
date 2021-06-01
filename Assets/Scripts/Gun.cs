using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class Gun : ScriptableObject
{
    // Gun Sprites for a specific gun, on different levels
    public Sprite[] sprites;       

    // Gun Name for a specific gun on each level
    public string[] gunName;

    public int level; 
    public int maxLevel;

    public Vector3[] position;
    public float[] radius;

    // 0 if gun only requires right hand
    // 1 if gun requires both hands
    public int[] requiresBothHands;


    // for POWER UP gun
    public bool isPowerUp;

    ///
    /// A Scriptable Object is only good for storing PRESET data values, 
    /// not saving data values during runtime.
    ///

    public void OnEnable()
    {
        for (int i = 0; i < position.Length; i++)
        {
            radius[i] = Mathf.Sqrt(position[i].x * position[i].x + position[i].y * position[i].y);
        }
    }
}

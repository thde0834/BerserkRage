using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

/// <summary>
/// FINDS Gun Asset File, LOADS Gun Data, and SETS X value
/// </summary>

public class RenderGun : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField]
    private Gun gun;

    public Transform pivot;

    // Change LATER when implementing choose weapon screen
    public string gunName;
    private string filePath;

    void Start()
    {
        filePath = "Guns\\" + gunName;
        if (File.Exists("Assets\\Resources\\" + filePath + ".asset"))
        {
            Debug.Log("[ChooseGun]: " + filePath + " loaded.");
            sr = GetComponent<SpriteRenderer>();
            gun = Resources.Load<Gun>(filePath);

            sr.sprite = gun.sprites[0];

            transform.position = new Vector3(gun.position[0].x, gun.position[0].y, 0);

        }
        else
        {
            Debug.Log("[ChooseGun]: <ERROR> NO FILE FOUND");
        }
    }


}

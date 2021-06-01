using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class RenderArm : MonoBehaviour
{
    private SpriteRenderer sr;
    public Arm arm;

    // CHANGE LATER
    public string armName;
    private string filePath;

    public int index;
    
    // Start is called before the first frame update
    void Start()
    {
        filePath = "Arms\\" + armName;
        if (File.Exists("Assets\\Resources\\" + filePath + ".asset"))
        {
            Debug.Log("[ChooseArm]: " + filePath + " loaded.");
            sr = GetComponent<SpriteRenderer>();
            arm = Resources.Load<Arm>(filePath);

            sr.sprite = arm.sprites[index];
        }
        else
        {
            Debug.Log("[ChooseArm]: <ERROR> NO FILE FOUND");
        }
    }

}

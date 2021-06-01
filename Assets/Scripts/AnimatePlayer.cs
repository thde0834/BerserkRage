using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class AnimatePlayer : MonoBehaviour
{
    private int currentFrame;
    private float timer;
    public float frameRate;
    
    private SpriteRenderer sr;
    public Body body;

    // Change LATER when implementing choose body screen
    public string bodyName;
    private string filePath;

    private int arrayLength;

    // Start is called before the first frame update
    private void Start()
    {
        filePath = "Bodies\\" + bodyName;
        if (File.Exists("Assets\\Resources\\" + filePath + ".asset"))
        {
            Debug.Log("[AnimatePlayer]: " + filePath + " loaded.");
            sr = GetComponent<SpriteRenderer>();
            body = Resources.Load<Body>(filePath);

            arrayLength = body.sprites.Length;
            sr.sprite = body.sprites[0];
            currentFrame = 0;
        }
        else
        {
            Debug.Log("[AnimatePlayer]: <ERROR> NO FILE FOUND");
        }       
    }

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= frameRate)
        {
            timer -= frameRate;
            currentFrame = (currentFrame + 1) % arrayLength;
            sr.sprite = body.sprites[currentFrame];
        }
        
    }
}

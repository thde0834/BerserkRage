using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class SpriteLoader : MonoBehaviour
{
    private SpriteRenderer sr;

    public Sprite GunSprite { get; private set; }

    private GunLoader gunLoader;

    [SerializeField]
    private Gun GunObject;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        GetComponent<GunController>().onStartEvent += onStart;
    }
    
    private void onStart(Gun gunObject)
    {
        GunObject = gunObject;
        SpriteChanger(0);
        sr.enabled = true;
    }

    private void SpriteChanger(int index)
    {
        GunSprite = GunObject.sprites[index];
        sr.sprite = GunSprite;
    }
}

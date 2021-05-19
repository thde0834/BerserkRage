using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private float startPos, length;
    public GameObject cam;
    public float parallaxValue;

    // Start is called before the first frame update
    void Start()
    {
        // Starting Position of a Layer, most likely (0, 0, 10)
        startPos = transform.position.x;
        // Length of the Layer PNG 
        length = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    // Update is called once per frame
    void Update()
    {
        float dist = (cam.transform.position.x * parallaxValue);
        float temp = (cam.transform.position.x * (1 - parallaxValue));

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        // Update as Camera max X reaches end of Layer PNG
        if (temp > startPos + length) startPos += length;
        else if (temp < startPos - length) startPos -= length;
    }
}

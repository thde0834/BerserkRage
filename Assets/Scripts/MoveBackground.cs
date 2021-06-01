using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private float startPos, length, velocity;
    public float parallaxValue;

    [SerializeField] private float dist;
    [SerializeField] private float temp;

    [SerializeField] private float timeElapsed;
    [SerializeField] private float distTravelled;

    // Start is called before the first frame update
    void Start()
    {
        // Starting Position of a Layer, most likely (0, 0, 10)
        startPos = transform.position.x;
        // Length of the Layer PNG 
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        // Set velocity to edgy memey value
        velocity = 6.66f;

    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        distTravelled = velocity * timeElapsed;

        //dist = (cam.transform.position.x * parallaxValue);
        //temp = (cam.transform.position.x * (1 - parallaxValue));

        dist = (distTravelled * parallaxValue);
        temp = (distTravelled * (1 - parallaxValue));

        //transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        transform.position = new Vector3(startPos - dist, transform.position.y, transform.position.z);

        // Update as Camera max X reaches end of Layer PNG
        //if (temp > startPos + length) startPos += length;
        //else if (temp < startPos - length) startPos -= length;

        if (dist > startPos + length) startPos += length;
        else if (dist < startPos - length) startPos -= length;
    }
}

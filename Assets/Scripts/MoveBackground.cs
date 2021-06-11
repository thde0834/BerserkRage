using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private float startPos, length, updateLength, velocity;
    public float parallaxValue;

    [SerializeField] private float dist;

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

        updateLength = 2 * length;

    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        distTravelled = velocity * timeElapsed;

        dist = (distTravelled * parallaxValue);

        transform.position = new Vector3(startPos - dist, transform.position.y, transform.position.z);

        if (dist > startPos + length) startPos += updateLength;
    }
}

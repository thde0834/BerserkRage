using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject cam;
    private float startPos, dist;
    public float velocity;

    // Start is called before the first frame update
    void Start()
    {
        // Get Starting Position of Camera (0,0)
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        dist += velocity * Time.deltaTime;
        // Move Camera at a constant velocity
        cam.transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
    }
}

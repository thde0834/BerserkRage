using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public float Angle { get; private set; }    // use for Bullet Launcher
    public float AngleInRad { get; private set; }    // use for Bullet Launcher

    public Transform outerCircle;
    public Transform innerCircle;

    [SerializeField]
    private float limit;

    public Transform gun;

    [SerializeField]
    private Vector2 pointA;
    [SerializeField]
    private Vector2 pointB;

    [SerializeField]
    private Vector2 offset;

    /// 
    /// Show Joy Stick (showJS)
    /// 0 = Hide Joystick
    /// 1 = Show Joystick
    /// 
    [SerializeField]
    private int showJS;

    // Start is called before the first frame update
    void Start()
    {
        // Game starts with >> hidden << Joystick
        showJS = 0;

        // Get Joystick Limit in X Axis
        limit = 0.5f * Screen.width;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Input.mousePosition.x < limit)
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            
            outerCircle.position = pointA;
            innerCircle.position = pointA;

            showJS = 1;

            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
            innerCircle.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (Input.GetMouseButton(0))
        {
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            showJS = 0;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
            innerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (pointB.x < pointA.x)
        {
            pointB.x = pointA.x;
        }
    
        if (pointA.x < 0)
        {
            rotateGun(Angle);
        }
        
    }

    private void FixedUpdate()
    {
        if (showJS == 1)
        {
            offset.x = pointB.x - pointA.x;
            offset.y = pointB.y - pointA.y;

            offset = Vector2.ClampMagnitude(offset, 1.0f);

            AngleInRad = Mathf.Atan2(offset.y, offset.x);
            Angle = AngleInRad * Mathf.Rad2Deg;

            innerCircle.position = new Vector2(pointA.x + offset.x, pointA.y + offset.y);

        }
    }

    void rotateGun(float angle)
    {
        gun.eulerAngles = new Vector3(0, 0, angle);
    }
}

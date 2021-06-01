using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPivot : MonoBehaviour
{
    public Transform player;
    [SerializeField]
    private Vector3 currPos;

    // Start is called before the first frame update
    void Start()
    {
        currPos = player.position;
        transform.position = currPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

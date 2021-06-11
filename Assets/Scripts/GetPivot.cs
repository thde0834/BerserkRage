using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPivot : MonoBehaviour
{
    public Transform player;
    
    public Vector3 Pivot { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Pivot = player.position;

        transform.position = Pivot;
    }

}

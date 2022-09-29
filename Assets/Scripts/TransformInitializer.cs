using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformInitializer : MonoBehaviour
{
    [field: SerializeField] public Vector3Variable Position { get; private set; }
    [field: SerializeField] public Vector3Variable Rotation { get; private set; }

    [field: SerializeField] public Color GizmosColor { get; private set; } = Color.red;

    private void Start()
    {
        
    }

    public void SetPosition(Vector3 position) => Position.SetValue(position);
}

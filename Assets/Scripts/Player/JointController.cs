using UnityEngine;

// UnityEngine's Transform Rotation is within [-90, 270]

public class JointController : MonoBehaviour
{
    [SerializeField] private FloatReference MinRotation;
    [SerializeField] private FloatReference MaxRotation;

    private Vector3 rotation = Vector3.zero;
    
    public bool CanRotate(float degrees) => MinRotation.Value <= degrees && degrees <= MaxRotation.Value;

    public void Rotate(float degrees)
    {
        if (this.CanRotate(degrees))
        {
            rotation.Set(0, 0, degrees);
            transform.localEulerAngles = rotation;
        }
    }
}
